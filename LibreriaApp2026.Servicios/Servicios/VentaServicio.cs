using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Entidades.Enums;
using LibreriaApp2026.Entidades.TipoLibro;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Venta;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class VentaServicio : IVentaServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public VentaServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result<int> Agregar(VentaCreateDto ventaDto)
        {
            if (ventaDto is null)
                return Result<int>.Failure("No se puede agregar una venta nula.");

            var errores = new List<string>();

            var cliente = _unitOfWork.Clientes.ObtenerPorId(ventaDto.ClienteId);
            if (cliente is null)
                errores.Add("El cliente no existe.");
            else if (!cliente.Activo)
                errores.Add("El cliente no está activo.");

            var formaDePago = _unitOfWork.FormasDePago.ObtenerPorId(ventaDto.FormaDePagoId);
            if (formaDePago is null)
                errores.Add("La forma de pago no existe.");
            else if (!formaDePago.Activo)
                errores.Add("La forma de pago no está activa.");


            var libros = new Dictionary<int, Libro>();

            if (ventaDto.Detalle is null || ventaDto.Detalle.Count == 0)
            {
                errores.Add("La venta debe tener al menos un libro.");
            }
            else
            {
                foreach (var item in ventaDto.Detalle)
                {
                    if (item.Cantidad <= 0)
                    {
                        errores.Add($"La cantidad de \"{item.Libro}\" debe ser mayor a cero.");
                        continue;
                    }

                    var libro = _unitOfWork.Libros.Query()
                        .Include(l => l.Editorial)
                        .FirstOrDefault(l => l.Id == item.LibroId);

                    if (libro is null)
                    {
                        errores.Add($"El libro con Id {item.LibroId} no existe.");
                        continue;
                    }

                    if (!libro.SePuedeVender())
                    {
                        errores.Add($"El libro \"{libro.Titulo}\" no está disponible para la venta.");
                        continue;
                    }


                    if (libro is LibroFisico fisico && fisico.Stock < item.Cantidad)
                    {
                        errores.Add($"Stock insuficiente de \"{libro.Titulo}\". " +
                                    $"Disponible: {fisico.Stock}, solicitado: {item.Cantidad}.");
                        continue;
                    }

                    libros[libro.Id] = libro;
                }
            }

            if (errores.Count > 0)
                return Result<int>.Failure(errores);

            try
            {
                var venta = new Venta(ventaDto.ClienteId, ventaDto.FormaDePagoId);

                foreach (var item in ventaDto.Detalle)
                {
                    var libro = libros[item.LibroId];


                    venta.AgregarDetalle(libro.Id, item.Cantidad, libro.Precio);

                    if (libro is LibroFisico fisico)
                    {
                        fisico.Stock -= item.Cantidad;
                    }
                }

                _unitOfWork.Ventas.Agregar(venta);
                _unitOfWork.SaveChanges();

                return Result<int>.Success(venta.VentaId);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result<int>.Failure(
                    "Otro usuario modificó uno de los libros. " +
                    "Actualice los datos e intente nuevamente.");
            }
            catch (DbUpdateException ex)
            {
                return Result<int>.Failure(
                    $"No se pudo registrar la venta: {ex.GetBaseException().Message}");
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al registrar la venta: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<VentaListDto>> ObtenerPaginado(
            int pagina, int cantidadPorPagina, string? textoBuscar = null)
        {
            try
            {
                var resultado = _unitOfWork.Ventas
                    .ObtenerPagina(pagina, cantidadPorPagina, textoBuscar);

                var paginado = new ResultadoPaginacionDto<VentaListDto>
                {
                    Items = resultado.lista.Select(v => v.ToListDto()).ToList(),
                    CantidadRegistros = resultado.cantidadRegistros,
                    CantidadPorPagina = cantidadPorPagina,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<VentaListDto>>.Success(paginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<VentaListDto>>
                    .Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<VentaDetailDto> ObtenerPorId(int ventaId)
        {
            try
            {
                var venta = _unitOfWork.Ventas.ObtenerPorId(ventaId);
                if (venta is null)
                    return Result<VentaDetailDto>.Failure($"No se encontró la venta N° {ventaId}.");

                return Result<VentaDetailDto>.Success(venta.ToDetailDto());
            }
            catch (Exception ex)
            {
                return Result<VentaDetailDto>.Failure($"Error al obtener la venta: {ex.Message}");
            }
        }

        public Result Facturar(int ventaId)
        {
            try
            {
                var venta = _unitOfWork.Ventas.ObtenerPorId(ventaId, tracked: true);
                if (venta is null)
                    return Result.Failure($"No existe la venta N° {ventaId}.");

                if (venta.EstadoVenta != EstadoVenta.Pendiente)
                    return Result.Failure("Solamente se pueden facturar ventas pendientes.");

                venta.Facturar();
                _unitOfWork.SaveChanges();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure(
                    "Otro usuario modificó esta venta. Actualice e intente nuevamente.");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al facturar la venta: {ex.Message}");
            }
        }

        public Result AnularVenta(int ventaId)
        {
            try
            {
                var venta = _unitOfWork.Ventas.ObtenerPorId(ventaId, tracked: true);
                if (venta is null)
                    return Result.Failure($"No existe la venta N° {ventaId}.");

                if (venta.EstadoVenta != EstadoVenta.Pendiente)
                    return Result.Failure("Solamente se pueden anular ventas pendientes.");


                foreach (var detalle in venta.Detalles)
                {
                    if (detalle.Libro is LibroFisico fisico)
                    {
                        fisico.Stock += detalle.Cantidad;
                    }
                }

                venta.Anular();
                _unitOfWork.SaveChanges();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure(
                    "Otro usuario modificó la venta o el stock. Actualice e intente nuevamente.");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al anular la venta: {ex.Message}");
            }
        }
        public Result<List<ClienteComboDto>> ObtenerClientes()
        {
            try
            {
                var lista = _unitOfWork.Clientes.Query()
                    .AsNoTracking()
                    .Where(c => c.Activo)
                    .OrderBy(c => c.Apellido).ThenBy(c => c.Nombre)
                    .Select(c => new ClienteComboDto
                    {
                        Id = c.ClienteId,
                        NombreCompleto = c.Apellido + ", " + c.Nombre
                    })
                    .ToList();
                return Result<List<ClienteComboDto>>.Success(lista);
            }
            catch (Exception ex)
            {
                return Result<List<ClienteComboDto>>.Failure($"Error al obtener los clientes: {ex.Message}");
            }
        }

        public Result<List<FormaDePagoComboDto>> ObtenerFormasDePago()
        {
            try
            {
                var lista = _unitOfWork.FormasDePago.Query()
                    .AsNoTracking()
                    .Where(f => f.Activo)
                    .OrderBy(f => f.Nombre)
                    .Select(f => new FormaDePagoComboDto
                    {
                        Id = f.FormaDePagoId,
                        Nombre = f.Nombre
                    })
                    .ToList();
                return Result<List<FormaDePagoComboDto>>.Success(lista);
            }
            catch (Exception ex)
            {
                return Result<List<FormaDePagoComboDto>>.Failure($"Error al obtener las formas de pago: {ex.Message}");
            }
        }

        public Result<List<LibroVentaDto>> ObtenerLibrosParaVenta()
        {
            try
            {
                var libros = _unitOfWork.Libros.Query()
                    .AsNoTracking()
                    .Include(l => l.Editorial)
                    .Where(l => l.Activo)
                    .OrderBy(l => l.Titulo)
                    .ToList()
                    .Where(l => l.SePuedeVender())
                    .Select(l => new LibroVentaDto
                    {
                        Id = l.Id,
                        Tipo = l.TipoDescripcion,
                        Codigo = l switch
                        {
                            LibroFisico f => f.ISBN,
                            LibroDigital d => d.Identificador,
                            _ => string.Empty
                        },
                        Titulo = l.Titulo,
                        Precio = l.Precio,
                        Stock = (l as LibroFisico)?.Stock
                    })
                    .ToList();

                return Result<List<LibroVentaDto>>.Success(libros);
            }
            catch (Exception ex)
            {
                return Result<List<LibroVentaDto>>.Failure($"Error al obtener los libros: {ex.Message}");
            }
        }
    }
}

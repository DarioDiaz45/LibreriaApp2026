using FluentValidation;
using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Cliente;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IValidator<ClienteCreateDto> _createValidator;
        private readonly IValidator<ClienteUpdateDto> _updateValidator;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteServicio(IUnitOfWork unitOfWork,
            IValidator<ClienteCreateDto> createValidator,
            IValidator<ClienteUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(ClienteCreateDto dto)
        {
            try
            {
                var validationResult = _createValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var cliente = ClienteMapper.ToEntidadCreate(dto);

                if (_unitOfWork.Clientes.Existe(c => c.Nombre == cliente.Nombre &&
                                                     c.Apellido == cliente.Apellido &&
                                                     c.Email == cliente.Email))
                {
                    return Result<int>.Failure("Ya existe un cliente con ese nombre, apellido y email.");
                }

                _unitOfWork.Clientes.Agregar(cliente);
                _unitOfWork.SaveChanges();

                return Result<int>.Success(cliente.ClienteId);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure($"Error al intentar agregar un cliente: {ex.Message}");
            }
        }

        public Result Editar(ClienteUpdateDto dto)
        {
            try
            {
                var validationResult = _updateValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var entidad = ClienteMapper.ToEntidadUpdate(dto);

                if (_unitOfWork.Clientes.Existe(c => c.Nombre == entidad.Nombre &&
                                                     c.Apellido == entidad.Apellido &&
                                                     c.Email == entidad.Email &&
                                                     c.ClienteId != entidad.ClienteId))
                {
                    return Result.Failure("Ya existe un cliente con ese nombre, apellido y email.");
                }

                _unitOfWork.Clientes.Editar(entidad, entidad.ClienteId);
                _unitOfWork.SaveChanges();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Cliente con ID {dto.ClienteId} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el cliente: {ex.Message}");
            }
        }

        public Result Borrar(ClienteDeleteDto dto)
        {
            try
            {
                if (_unitOfWork.Clientes.TieneVentasAsociadas(dto.ClienteId))
                {
                    return Result.Failure("No se puede eliminar el cliente porque tiene ventas asociadas.");
                }

                _unitOfWork.Clientes.Borrar(dto.ClienteId, dto.RowVersion);
                _unitOfWork.SaveChanges();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyFailure("Otro usuario modificó el registro\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Cliente con ID: {dto.ClienteId} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar un cliente: {ex.Message}");
            }
        }

        public Result<ClienteUpdateDto> ObtenerParaEditar(int id)
        {
            
            var cliente = _unitOfWork.Clientes.Query()
                .AsNoTracking()
                .FirstOrDefault(c => c.ClienteId == id);

            return cliente != null
                ? Result<ClienteUpdateDto>.Success(ClienteMapper.ToUpdateDto(cliente))
                : Result<ClienteUpdateDto>.Failure("Cliente no encontrado!!!");
        }

        public Result<ClienteDeleteDto> ObtenerParaBorrar(int id)
        {
            var cliente = _unitOfWork.Clientes.Query()
                .AsNoTracking()
                .FirstOrDefault(c => c.ClienteId == id);

            return cliente != null
                ? Result<ClienteDeleteDto>.Success(ClienteMapper.ToDeleteDto(cliente))
                : Result<ClienteDeleteDto>.Failure("Error al intentar obtener el cliente");
        }

        private static Expression<Func<Cliente, bool>> ConstruirFiltro(bool? filtroActivo, string? textoBuscar)
        {
            return c =>
                (filtroActivo == null || c.Activo == filtroActivo) &&
                (string.IsNullOrWhiteSpace(textoBuscar) ||
                 c.Nombre.Contains(textoBuscar) ||
                 c.Apellido.Contains(textoBuscar));
        }

        public Result<ResultadoPaginacionDto<ClienteListDto>> ObtenerPagina(
            int pagina, int cantidad, string campoOrdenar, bool esAscendente,
            bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                var filtro = ConstruirFiltro(filtroActivo, textoBuscar);

                Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>> ordenarPor = campoOrdenar switch
                {
                    "ClienteId" => q => esAscendente
                        ? q.OrderBy(c => c.ClienteId)
                        : q.OrderByDescending(c => c.ClienteId),
                    _ => q => esAscendente
                        ? q.OrderBy(c => c.Apellido).ThenBy(c => c.Nombre)
                        : q.OrderByDescending(c => c.Apellido).ThenByDescending(c => c.Nombre),
                };

                var resultado = _unitOfWork.Clientes.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);

                var paginado = new ResultadoPaginacionDto<ClienteListDto>
                {
                    Items = resultado.lista.Select(ClienteMapper.ToListDto).ToList(),
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<ClienteListDto>>.Success(paginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<ClienteListDto>>
                    .Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                var filtro = ConstruirFiltro(filtroActivo, textoBuscar);
                var posicion = _unitOfWork.Clientes.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(Math.Max(pagina, 1));
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }
    }
}

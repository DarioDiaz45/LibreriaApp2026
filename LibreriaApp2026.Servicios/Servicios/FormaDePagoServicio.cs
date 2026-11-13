using FluentValidation;
using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.FormaDePago;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class FormaDePagoServicio : IFormaDePagoServicio
    {
        private readonly IValidator<FormaDePagoCreateDto> _createValidator;
        private readonly IValidator<FormaDePagoUpdateDto> _updateValidator;
        private readonly IUnitOfWork _unitOfWork;

        public FormaDePagoServicio(IUnitOfWork unitOfWork,
            IValidator<FormaDePagoCreateDto> createValidator,
            IValidator<FormaDePagoUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(FormaDePagoCreateDto dto)
        {
            try
            {
                var validationResult = _createValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var forma = FormaDePagoMapper.ToEntidadCreate(dto);

                if (_unitOfWork.FormasDePago.Existe(f => f.Nombre == forma.Nombre))
                {
                    return Result<int>.Failure("Ya existe una forma de pago con ese nombre.");
                }

                _unitOfWork.FormasDePago.Agregar(forma);
                _unitOfWork.SaveChanges();

                return Result<int>.Success(forma.FormaDePagoId);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure($"Error al intentar agregar una forma de pago: {ex.Message}");
            }
        }

        public Result Editar(FormaDePagoUpdateDto dto)
        {
            try
            {
                var validationResult = _updateValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var entidad = FormaDePagoMapper.ToEntidadUpdate(dto);

                if (_unitOfWork.FormasDePago.Existe(f => f.Nombre == entidad.Nombre &&
                                                         f.FormaDePagoId != entidad.FormaDePagoId))
                {
                    return Result.Failure("Ya existe una forma de pago con ese nombre.");
                }

                _unitOfWork.FormasDePago.Editar(entidad, entidad.FormaDePagoId);
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
                return Result.Failure($"Forma de pago con ID {dto.FormaDePagoId} no encontrada");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar la forma de pago: {ex.Message}");
            }
        }

        public Result Borrar(FormaDePagoDeleteDto dto)
        {
            try
            {
                if (_unitOfWork.FormasDePago.TieneVentasAsociadas(dto.FormaDePagoId))
                {
                    return Result.Failure("No se puede eliminar la forma de pago porque tiene ventas asociadas.");
                }

                _unitOfWork.FormasDePago.Borrar(dto.FormaDePagoId, dto.RowVersion);
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
                return Result.Failure($"Forma de pago con ID: {dto.FormaDePagoId} no encontrada");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar la forma de pago: {ex.Message}");
            }
        }

        public Result<FormaDePagoUpdateDto> ObtenerParaEditar(int id)
        {

            var forma = _unitOfWork.FormasDePago.Query()
                .AsNoTracking()
                .FirstOrDefault(f => f.FormaDePagoId == id);

            return forma != null
                ? Result<FormaDePagoUpdateDto>.Success(FormaDePagoMapper.ToUpdateDto(forma))
                : Result<FormaDePagoUpdateDto>.Failure("Forma de pago no encontrada!!!");
        }

        public Result<FormaDePagoDeleteDto> ObtenerParaBorrar(int id)
        {
            var forma = _unitOfWork.FormasDePago.Query()
                .AsNoTracking()
                .FirstOrDefault(f => f.FormaDePagoId == id);

            return forma != null
                ? Result<FormaDePagoDeleteDto>.Success(FormaDePagoMapper.ToDeleteDto(forma))
                : Result<FormaDePagoDeleteDto>.Failure("Error al intentar obtener la forma de pago");
        }

        private static Expression<Func<FormaDePago, bool>> ConstruirFiltro(bool? filtroActivo, string? textoBuscar)
        {
            return f =>
                (filtroActivo == null || f.Activo == filtroActivo) &&
                (string.IsNullOrWhiteSpace(textoBuscar) || f.Nombre.Contains(textoBuscar));
        }

        public Result<ResultadoPaginacionDto<FormaDePagoListDto>> ObtenerPagina(
            int pagina, int cantidad, string campoOrdenar, bool esAscendente,
            bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                var filtro = ConstruirFiltro(filtroActivo, textoBuscar);

                Func<IQueryable<FormaDePago>, IOrderedQueryable<FormaDePago>> ordenarPor = campoOrdenar switch
                {
                    "FormaDePagoId" => q => esAscendente
                        ? q.OrderBy(f => f.FormaDePagoId)
                        : q.OrderByDescending(f => f.FormaDePagoId),
                    _ => q => esAscendente
                        ? q.OrderBy(f => f.Nombre)
                        : q.OrderByDescending(f => f.Nombre),
                };

                var resultado = _unitOfWork.FormasDePago.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);

                var paginado = new ResultadoPaginacionDto<FormaDePagoListDto>
                {
                    Items = resultado.lista.Select(FormaDePagoMapper.ToListDto).ToList(),
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<FormaDePagoListDto>>.Success(paginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<FormaDePagoListDto>>
                    .Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                var filtro = ConstruirFiltro(filtroActivo, textoBuscar);
                var posicion = _unitOfWork.FormasDePago.ObtenerPosicionRegistro(seleccionadoId, filtro);
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

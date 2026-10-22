using FluentValidation;
using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Editorial;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class EditorialServicio : IEditorialServicio
    {
        private readonly IValidator<EditorialCreateDto> _createValidator;
        private readonly IValidator<EditorialUpdateDto> _updateValidator;
        private readonly IUnitOfWork _unitOfWork;

        public EditorialServicio(IUnitOfWork unitOfWork,
            IValidator<EditorialCreateDto> createValidator,
            IValidator<EditorialUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(EditorialCreateDto editorialDto)
        {
            try
            {

                var validationResult = _createValidator.Validate(editorialDto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }


                var editorial = EditorialMapper.ToEntidadCreate(editorialDto);


                if (_unitOfWork.Editoriales.Existe(e => e.Nombre == editorial.Nombre))
                {
                    return Result<int>.Failure($"Ya existe un editorial con el nombre {editorial.Nombre}");
                }

                _unitOfWork.Editoriales.Agregar(editorial);
                _unitOfWork.SaveChanges();

                return Result<int>.Success(editorial.Id);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure($"Error al intentar agregar un tipo de bombón: {ex.Message}");
            }
        }

        public Result Editar(EditorialUpdateDto dto)
        {
            try
            {

                var validationResult = _updateValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }


                var entidad = EditorialMapper.ToEntidadUpdate(dto);


                if (_unitOfWork.Editoriales.Existe(e => e.Nombre == entidad.Nombre && e.Id != entidad.Id))
                {
                    return Result.Failure("Ya existe una editorial con ese nombre.");
                }

                _unitOfWork.Editoriales.Editar(entidad, entidad.Id);
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
                return Result.Failure($"Editorial con ID {dto.Id} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el tipo de bombón: {ex.Message}");
            }
        }

        public Result Borrar(EditorialDeleteDto dto)
        {
            try
            {
                _unitOfWork.Editoriales.Borrar(dto.Id, dto.RowVersion);
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
                return Result.Failure($"Editorial con ID: {dto.Id} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar un editorial: {ex.Message}");
            }
        }

        public Result<List<EditorialListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Editoriales.ObtenerTodos();
                var listaDto = lista.Select(e => EditorialMapper.ToListDto(e)).ToList();
                return Result<List<EditorialListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<EditorialListDto>>.Failure(ex.Message);
            }
        }

        public Result<EditorialListDto> ObtenerPorId(int id)
        {
            try
            {
                var editorial = _unitOfWork.Editoriales.ObtenerPorId(id);
                if (editorial != null)
                {
                    var editorialDto = EditorialMapper.ToListDto(editorial);
                    return Result<EditorialListDto>.Success(editorialDto);
                }

                return Result<EditorialListDto>.Failure("Editorial no encontrado!!!");
            }
            catch (Exception ex)
            {
                return Result<EditorialListDto>.Failure(ex.Message);
            }
        }

        public Result<EditorialUpdateDto> ObtenerParaEditar(int id)
        {
            var editorial = _unitOfWork.Editoriales.Query()
               .AsNoTracking()
               .FirstOrDefault(e => e.Id == id);

            if (editorial != null)
            {
                var dto = EditorialMapper.ToUpdateDto(editorial);
                return Result<EditorialUpdateDto>.Success(dto);
            }

            return Result<EditorialUpdateDto>.Failure("Editorial no encontrado!!!");
        }

        public Result<EditorialDeleteDto> ObtenerParaBorrar(int id)
        {
            var editorial = _unitOfWork.Editoriales.ObtenerPorId(id);
            if (editorial != null)
            {
                var editorialDto = EditorialMapper.ToDeleteDto(editorial);
                return Result<EditorialDeleteDto>.Success(editorialDto);
            }

            return Result<EditorialDeleteDto>.Failure("Error al intentar obtener el editorial");
        }



        public Result<ResultadoPaginacionDto<EditorialListDto>> ObtenerPagina(
            int pagina,
            int cantidad,
            string campoOrden,
            bool esAscendente,
            string? filtroPais = null,
            string? textoBuscar = null,
             bool? filtroActivo = null)
        {
            try
            {
                Expression<Func<Editorial, bool>>? filtro = b =>
                 (filtroActivo == null || b.Activo == filtroActivo) &&
                 (string.IsNullOrWhiteSpace(textoBuscar) || b.Nombre.Contains(textoBuscar));

                Func<IQueryable<Editorial>, IOrderedQueryable<Editorial>>? ordenarPor = campoOrden switch
                {
                    "EditorialId" => q => esAscendente ? q.OrderBy(e => e.Id) : q.OrderByDescending(e => e.Id),
                    _ => q => esAscendente ? q.OrderBy(e => e.Nombre) : q.OrderByDescending(e => e.Nombre),
                };

                var resultado = _unitOfWork.Editoriales.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(tb => EditorialMapper.ToListDto(tb)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<EditorialListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<EditorialListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<EditorialListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            string? filtroPais = null, string? textoBuscar = null, bool? filtroActivo = null)
        {
            try
            {
                Expression<Func<Editorial, bool>>? filtro = b =>
             (string.IsNullOrWhiteSpace(filtroPais) || b.PaisOrigen == filtroPais) &&
             (filtroActivo == null || b.Activo == filtroActivo) &&
             (string.IsNullOrWhiteSpace(textoBuscar) || b.Nombre.Contains(textoBuscar));


                var posicion = _unitOfWork.Editoriales.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }


    }
}

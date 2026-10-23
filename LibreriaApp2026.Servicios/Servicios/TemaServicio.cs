using FluentValidation;
using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Tema;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class TemaServicio : ITemaServicio
    {
        private readonly IValidator<TemaCreateDto> _createValidator;
        private readonly IValidator<TemaUpdateDto> _updateValidator;
        private readonly IUnitOfWork _unitOfWork;

        public TemaServicio(IUnitOfWork unitOfWork,
            IValidator<TemaCreateDto> createValidator,
            IValidator<TemaUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(TemaCreateDto dto)
        {
            try
            {
                var validationResult = _createValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var tema = TemaMapper.ToEntidadCreate(dto);

                if (_unitOfWork.Temas.Existe(t => t.Nombre == tema.Nombre))
                {
                    return Result<int>.Failure($"Ya existe un tema con el nombre {tema.Nombre}");
                }

                _unitOfWork.Temas.Agregar(tema);
                _unitOfWork.SaveChanges();

                return Result<int>.Success(tema.Id);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure($"Error al intentar agregar un tema: {ex.Message}");
            }
        }

        public Result Editar(TemaUpdateDto dto)
        {
            try
            {
                var validationResult = _updateValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var entidad = TemaMapper.ToEntidadUpdate(dto);

                if (_unitOfWork.Temas.Existe(t => t.Nombre == entidad.Nombre && t.Id != entidad.Id))
                {
                    return Result.Failure("Ya existe un tema con ese nombre.");
                }

                _unitOfWork.Temas.Editar(entidad, entidad.Id);
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
                return Result.Failure($"Tema con ID {dto.Id} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el tema: {ex.Message}");
            }
        }

        public Result Borrar(TemaDeleteDto dto)
        {
            try
            {
                if (_unitOfWork.Temas.TieneLibrosAsociados(dto.Id))
                {
                    return Result.Failure("No se puede eliminar el tema porque tiene libros asociados.");
                }

                _unitOfWork.Temas.Borrar(dto.Id, dto.RowVersion);
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
                return Result.Failure($"Tema con ID: {dto.Id} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar un tema: {ex.Message}");
            }
        }

        public Result<List<TemaListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Temas.ObtenerTodos();
                var listaDto = lista.Select(TemaMapper.ToListDto).ToList();
                return Result<List<TemaListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<TemaListDto>>.Failure(ex.Message);
            }
        }

        public Result<TemaListDto> ObtenerPorId(int id)
        {
            try
            {
                var tema = _unitOfWork.Temas.Query()
                    .AsNoTracking()
                    .FirstOrDefault(t => t.Id == id);
                if (tema != null)
                {
                    return Result<TemaListDto>.Success(TemaMapper.ToListDto(tema));
                }

                return Result<TemaListDto>.Failure("Tema no encontrado!!!");
            }
            catch (Exception ex)
            {
                return Result<TemaListDto>.Failure(ex.Message);
            }
        }

        public Result<TemaUpdateDto> ObtenerParaEditar(int id)
        {
            
            var tema = _unitOfWork.Temas.Query()
                .AsNoTracking()
                .FirstOrDefault(t => t.Id == id);
            if (tema != null)
            {
                return Result<TemaUpdateDto>.Success(TemaMapper.ToUpdateDto(tema));
            }

            return Result<TemaUpdateDto>.Failure("Tema no encontrado!!!");
        }

        public Result<TemaDeleteDto> ObtenerParaBorrar(int id)
        {
            var tema = _unitOfWork.Temas.Query()
                .AsNoTracking()
                .FirstOrDefault(t => t.Id == id);
            if (tema != null)
            {
                return Result<TemaDeleteDto>.Success(TemaMapper.ToDeleteDto(tema));
            }

            return Result<TemaDeleteDto>.Failure("Error al intentar obtener el tema");
        }

        public Result<ResultadoPaginacionDto<TemaListDto>> ObtenerPagina(
            int pagina,
            int cantidad,
            string campoOrden,
            bool esAscendente,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Tema, bool>>? filtro = t =>
                    string.IsNullOrWhiteSpace(textoBuscar) ||
                    t.Nombre.Contains(textoBuscar);

                Func<IQueryable<Tema>, IOrderedQueryable<Tema>> ordenarPor = campoOrden switch
                {
                    "Id" => q => esAscendente ? q.OrderBy(t => t.Id) : q.OrderByDescending(t => t.Id),
                    _ => q => esAscendente ? q.OrderBy(t => t.Nombre) : q.OrderByDescending(t => t.Nombre),
                };

                var resultado = _unitOfWork.Temas.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(TemaMapper.ToListDto).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<TemaListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<TemaListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<TemaListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Tema, bool>>? filtro = t =>
                    string.IsNullOrWhiteSpace(textoBuscar) ||
                    t.Nombre.Contains(textoBuscar);

                var posicion = _unitOfWork.Temas.ObtenerPosicionRegistro(seleccionadoId, filtro);
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

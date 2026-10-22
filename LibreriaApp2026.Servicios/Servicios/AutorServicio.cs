using FluentValidation;
using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Autor;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class AutorServicio : IAutorServicio
    {
        private readonly IValidator<AutorCreateDto> _createValidator;
        private readonly IValidator<AutorUpdateDto> _updateValidator;
        private readonly IUnitOfWork _unitOfWork;

        public AutorServicio(IUnitOfWork unitOfWork,
            IValidator<AutorCreateDto> createValidator,
            IValidator<AutorUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(AutorCreateDto dto)
        {
            try
            {
                var validationResult = _createValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var autor = AutorMapper.ToEntidadCreate(dto);

                if (_unitOfWork.Autores.Existe(a => a.Nombre == autor.Nombre &&
                                                    a.Apellido == autor.Apellido &&
                                                    a.FechaNacimiento == autor.FechaNacimiento))
                {
                    return Result<int>.Failure("Ya existe un autor con ese nombre, apellido y fecha de nacimiento.");
                }

                _unitOfWork.Autores.Agregar(autor);
                _unitOfWork.SaveChanges();

                return Result<int>.Success(autor.Id);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure($"Error al intentar agregar un autor: {ex.Message}");
            }
        }

        public Result Editar(AutorUpdateDto dto)
        {
            try
            {
                var validationResult = _updateValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var entidad = AutorMapper.ToEntidadUpdate(dto);

                if (_unitOfWork.Autores.Existe(a => a.Nombre == entidad.Nombre &&
                                                    a.Apellido == entidad.Apellido &&
                                                    a.FechaNacimiento == entidad.FechaNacimiento &&
                                                    a.Id != entidad.Id))
                {
                    return Result.Failure("Ya existe un autor con ese nombre, apellido y fecha de nacimiento.");
                }

                _unitOfWork.Autores.Editar(entidad, entidad.Id);
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
                return Result.Failure($"Autor con ID {dto.Id} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el autor: {ex.Message}");
            }
        }

        public Result Borrar(AutorDeleteDto dto)
        {
            try
            {
                if (_unitOfWork.Autores.TieneLibrosAsociados(dto.Id))
                {
                    return Result.Failure("No se puede eliminar el autor porque tiene libros asociados.");
                }

                _unitOfWork.Autores.Borrar(dto.Id, dto.RowVersion);
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
                return Result.Failure($"Autor con ID: {dto.Id} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar un autor: {ex.Message}");
            }
        }

        public Result<List<AutorListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Autores.ObtenerTodos();
                var listaDto = lista.Select(AutorMapper.ToListDto).ToList();
                return Result<List<AutorListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<AutorListDto>>.Failure(ex.Message);
            }
        }

        public Result<AutorListDto> ObtenerPorId(int id)
        {
            try
            {
                var autor = _unitOfWork.Autores.Query()
                    .AsNoTracking()
                    .FirstOrDefault(a => a.Id == id);
                if (autor != null)
                {
                    return Result<AutorListDto>.Success(AutorMapper.ToListDto(autor));
                }

                return Result<AutorListDto>.Failure("Autor no encontrado!!!");
            }
            catch (Exception ex)
            {
                return Result<AutorListDto>.Failure(ex.Message);
            }
        }

        public Result<AutorUpdateDto> ObtenerParaEditar(int id)
        {
            // Sin rastreo: evita "another instance with the same key is already being tracked"
            var autor = _unitOfWork.Autores.Query()
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);
            if (autor != null)
            {
                return Result<AutorUpdateDto>.Success(AutorMapper.ToUpdateDto(autor));
            }

            return Result<AutorUpdateDto>.Failure("Autor no encontrado!!!");
        }

        public Result<AutorDeleteDto> ObtenerParaBorrar(int id)
        {
            var autor = _unitOfWork.Autores.Query()
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);
            if (autor != null)
            {
                return Result<AutorDeleteDto>.Success(AutorMapper.ToDeleteDto(autor));
            }

            return Result<AutorDeleteDto>.Failure("Error al intentar obtener el autor");
        }

        public Result<ResultadoPaginacionDto<AutorListDto>> ObtenerPagina(
            int pagina,
            int cantidad,
            string campoOrden,
            bool esAscendente,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Autor, bool>>? filtro = a =>
                    string.IsNullOrWhiteSpace(textoBuscar) ||
                    a.Nombre.Contains(textoBuscar) ||
                    a.Apellido.Contains(textoBuscar);

                Func<IQueryable<Autor>, IOrderedQueryable<Autor>> ordenarPor = campoOrden switch
                {
                    "Id" => q => esAscendente ? q.OrderBy(a => a.Id) : q.OrderByDescending(a => a.Id),
                    "Nacionalidad" => q => esAscendente
                        ? q.OrderBy(a => a.Nacionalidad).ThenBy(a => a.Apellido)
                        : q.OrderByDescending(a => a.Nacionalidad).ThenBy(a => a.Apellido),
                    _ => q => esAscendente
                        ? q.OrderBy(a => a.Apellido).ThenBy(a => a.Nombre)
                        : q.OrderByDescending(a => a.Apellido).ThenByDescending(a => a.Nombre),
                };

                var resultado = _unitOfWork.Autores.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(AutorMapper.ToListDto).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<AutorListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<AutorListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<AutorListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Autor, bool>>? filtro = a =>
                    string.IsNullOrWhiteSpace(textoBuscar) ||
                    a.Nombre.Contains(textoBuscar) ||
                    a.Apellido.Contains(textoBuscar);

                var posicion = _unitOfWork.Autores.ObtenerPosicionRegistro(seleccionadoId, filtro);
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

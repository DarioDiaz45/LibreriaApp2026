using FluentValidation;
using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Entidades.TipoLibro;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Libro;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class LibroServicio:ILibroServicio
    {
        private readonly IValidator<LibroCreateDto> _createValidator;
        private readonly IValidator<LibroUpdateDto> _updateValidator;
        private readonly IUnitOfWork _unitOfWork;

        public LibroServicio(IUnitOfWork unitOfWork,
            IValidator<LibroCreateDto> createValidator,
            IValidator<LibroUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(LibroCreateDto dto)
        {
            try
            {
                var validationResult = _createValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var errorCodigo = ValidarCodigoUnico(dto, null);
                if (errorCodigo is not null)
                {
                    return Result<int>.Failure(errorCodigo);
                }

                if (!_unitOfWork.Editoriales.Existe(e => e.Id == dto.EditorialId))
                {
                    return Result<int>.Failure("La editorial seleccionada no existe.");
                }

                var libro = LibroMapper.ToEntidadCreate(dto);

                var error = AsignarRelaciones(libro, dto.AutoresIds, dto.TemasIds);
                if (error is not null)
                {
                    return Result<int>.Failure(error);
                }

                _unitOfWork.Libros.Agregar(libro);
                _unitOfWork.SaveChanges();

                return Result<int>.Success(libro.Id);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure($"Error al intentar agregar un libro: {ex.Message}");
            }
        }

        public Result Editar(LibroUpdateDto dto)
        {
            try
            {
                var validationResult = _updateValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var errorCodigo = ValidarCodigoUnico(dto, dto.Id);
                if (errorCodigo is not null)
                {
                    return Result.Failure(errorCodigo);
                }

                if (!_unitOfWork.Editoriales.Existe(e => e.Id == dto.EditorialId))
                {
                    return Result.Failure("La editorial seleccionada no existe.");
                }

                
                var libro = _unitOfWork.Libros.ObtenerConRelaciones(dto.Id);
                if (libro is null)
                {
                    return Result.Failure($"Libro con ID {dto.Id} no encontrado");
                }

                var tipoActual = libro is LibroFisico ? TipoLibro.Fisico : TipoLibro.Digital;
                if (tipoActual != dto.Tipo)
                {
                    return Result.Failure("No se puede cambiar el tipo de un libro (físico/digital).");
                }

                _unitOfWork.Libros.EstablecerRowVersion(libro, dto.RowVersion);

                LibroMapper.AplicarCambios(libro, dto);

                var error = AsignarRelaciones(libro, dto.AutoresIds, dto.TemasIds);
                if (error is not null)
                {
                    _unitOfWork.RollBack();
                    return Result.Failure(error);
                }

                _unitOfWork.SaveChanges();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el libro: {ex.Message}");
            }
        }

        public Result Borrar(LibroDeleteDto dto)
        {
            try
            {
                _unitOfWork.Libros.Borrar(dto.Id, dto.RowVersion);
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
                return Result.Failure($"Libro con ID: {dto.Id} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar un libro: {ex.Message}");
            }
        }

        public Result<LibroUpdateDto> ObtenerParaEditar(int id)
        {
           
            var libro = _unitOfWork.Libros.Query()
                .AsNoTracking()
                .Include(l => l.Autores)
                .Include(l => l.Temas)
                .FirstOrDefault(l => l.Id == id);

            if (libro != null)
            {
                return Result<LibroUpdateDto>.Success(LibroMapper.ToUpdateDto(libro));
            }

            return Result<LibroUpdateDto>.Failure("Libro no encontrado!!!");
        }

        public Result<LibroDeleteDto> ObtenerParaBorrar(int id)
        {
            var libro = _unitOfWork.Libros.Query()
                .AsNoTracking()
                .FirstOrDefault(l => l.Id == id);

            if (libro != null)
            {
                return Result<LibroDeleteDto>.Success(LibroMapper.ToDeleteDto(libro));
            }

            return Result<LibroDeleteDto>.Failure("Error al intentar obtener el libro");
        }

        public Result<ResultadoPaginacionDto<LibroListDto>> ObtenerPagina(
            int pagina,
            int cantidad,
            string campoOrden,
            bool esAscendente,
            int? editorialId = null,
            int? autorId = null,
            int? temaId = null,
            string? textoBuscar = null)
        {
            try
            {
                var filtro = ConstruirFiltro(editorialId, autorId, temaId, textoBuscar);

                Func<IQueryable<Libro>, IOrderedQueryable<Libro>> ordenarPor = campoOrden switch
                {
                    "Id" => q => esAscendente ? q.OrderBy(l => l.Id) : q.OrderByDescending(l => l.Id),
                    _ => q => esAscendente ? q.OrderBy(l => l.Titulo) : q.OrderByDescending(l => l.Titulo),
                };

                var resultado = _unitOfWork.Libros.ObtenerPagina(
                    pagina, cantidad, ordenarPor, filtro,
                    q => q.Include(l => l.Editorial)
                          .Include(l => l.Autores)
                          .Include(l => l.Temas));

                var listaDto = resultado.lista.Select(LibroMapper.ToListDto).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<LibroListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<LibroListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<LibroListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            int? editorialId = null, int? autorId = null, int? temaId = null,
            string? textoBuscar = null)
        {
            try
            {
                var filtro = ConstruirFiltro(editorialId, autorId, temaId, textoBuscar);

                var posicion = _unitOfWork.Libros.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(Math.Max(pagina, 1));
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        
        private static Expression<Func<Libro, bool>> ConstruirFiltro(
            int? editorialId, int? autorId, int? temaId, string? textoBuscar)
        {
            return l =>
                (editorialId == null || l.EditorialId == editorialId) &&
                (autorId == null || l.Autores.Any(a => a.Id == autorId)) &&
                (temaId == null || l.Temas.Any(t => t.Id == temaId)) &&
                (string.IsNullOrWhiteSpace(textoBuscar) ||
                    l.Titulo.Contains(textoBuscar) ||
                    (l is LibroFisico && ((LibroFisico)l).ISBN.Contains(textoBuscar)) ||
                    (l is LibroDigital && ((LibroDigital)l).Identificador.Contains(textoBuscar)));
        }

       
        private string? ValidarCodigoUnico(LibroCreateDto dto, int? excluirId)
        {
            if (dto.Tipo == TipoLibro.Fisico)
            {
                var existe = _unitOfWork.Libros.Query().OfType<LibroFisico>()
                    .Any(l => l.ISBN == dto.ISBN && (excluirId == null || l.Id != excluirId));
                return existe ? $"Ya existe un libro con el ISBN {dto.ISBN}" : null;
            }

            var existeDigital = _unitOfWork.Libros.Query().OfType<LibroDigital>()
                .Any(l => l.Identificador == dto.Identificador && (excluirId == null || l.Id != excluirId));
            return existeDigital ? $"Ya existe un libro digital con el identificador {dto.Identificador}" : null;
        }

        
        private string? AsignarRelaciones(Libro libro, IEnumerable<int> autoresIds, IEnumerable<int> temasIds)
        {
            libro.Autores.Clear();
            foreach (var id in autoresIds.Distinct())
            {
                var autor = _unitOfWork.Autores.ObtenerPorId(id);
                if (autor is null) return $"El autor con ID {id} no existe.";
                libro.Autores.Add(autor);
            }

            libro.Temas.Clear();
            foreach (var id in temasIds.Distinct())
            {
                var tema = _unitOfWork.Temas.ObtenerPorId(id);
                if (tema is null) return $"El tema con ID {id} no existe.";
                libro.Temas.Add(tema);
            }

            return null;
        }
        public Result<LibroDetailDto> ObtenerDetalle(int id)
        {
            try
            {
                var libro = _unitOfWork.Libros.Query()
                    .AsNoTracking()
                    .Include(l => l.Editorial)
                    .Include(l => l.Autores)
                    .Include(l => l.Temas)
                    .FirstOrDefault(l => l.Id == id);

                if (libro is null)
                {
                    return Result<LibroDetailDto>.Failure("Libro no encontrado!!!");
                }

                return Result<LibroDetailDto>.Success(LibroMapper.ToDetalleDto(libro));
            }
            catch (Exception ex)
            {
                return Result<LibroDetailDto>.Failure($"Error al obtener el detalle del libro: {ex.Message}");
            }
        }
    }
}

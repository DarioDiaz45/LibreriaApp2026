using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Libro;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface ILibroServicio
    {
        Result<LibroUpdateDto> ObtenerParaEditar(int id);
        Result<LibroDeleteDto> ObtenerParaBorrar(int id);
        Result<LibroDetailDto> ObtenerDetalle(int id);

        Result<int> Agregar(LibroCreateDto libroDto);
        Result Editar(LibroUpdateDto libroDto);
        Result Borrar(LibroDeleteDto libroDto);

        Result<ResultadoPaginacionDto<LibroListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            int? editorialId = null, int? autorId = null, int? temaId = null,
            string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            int? editorialId = null, int? autorId = null, int? temaId = null,
            string? textoBuscar = null);
    }
}

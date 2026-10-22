using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Editorial;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface IEditorialServicio
    {
        Result<List<EditorialListDto>> ObtenerTodos();
        Result<EditorialListDto> ObtenerPorId(int id);
        Result<EditorialUpdateDto> ObtenerParaEditar(int id);
        Result<EditorialDeleteDto> ObtenerParaBorrar(int id);

        Result<int> Agregar(EditorialCreateDto editorialDto);
        Result Editar(EditorialUpdateDto editorialDto);
        Result Borrar(EditorialDeleteDto editorialDto);
        
        Result<ResultadoPaginacionDto<EditorialListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            string? filtroPais = null, string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
           string? filtroPais = null, string? textoBuscar = null);
       

    }
}

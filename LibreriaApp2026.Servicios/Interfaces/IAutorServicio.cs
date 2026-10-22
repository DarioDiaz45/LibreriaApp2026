using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Autor;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface IAutorServicio
    {
        Result<List<AutorListDto>> ObtenerTodos();
        Result<AutorListDto> ObtenerPorId(int id);
        Result<AutorUpdateDto> ObtenerParaEditar(int id);
        Result<AutorDeleteDto> ObtenerParaBorrar(int id);

        Result<int> Agregar(AutorCreateDto autorDto);
        Result Editar(AutorUpdateDto autorDto);
        Result Borrar(AutorDeleteDto autorDto);

        Result<ResultadoPaginacionDto<AutorListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            string? textoBuscar = null);
    }
}


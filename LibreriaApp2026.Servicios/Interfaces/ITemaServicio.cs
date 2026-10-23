using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Tema;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface ITemaServicio
    {
        Result<List<TemaListDto>> ObtenerTodos();
        Result<TemaListDto> ObtenerPorId(int id);
        Result<TemaUpdateDto> ObtenerParaEditar(int id);
        Result<TemaDeleteDto> ObtenerParaBorrar(int id);

        Result<int> Agregar(TemaCreateDto temaDto);
        Result Editar(TemaUpdateDto temaDto);
        Result Borrar(TemaDeleteDto temaDto);

        Result<ResultadoPaginacionDto<TemaListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            string? textoBuscar = null);
    }
}

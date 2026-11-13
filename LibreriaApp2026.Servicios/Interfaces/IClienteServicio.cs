using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Cliente;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface IClienteServicio
    {
        Result<ClienteUpdateDto> ObtenerParaEditar(int id);
        Result<ClienteDeleteDto> ObtenerParaBorrar(int id);

        Result<int> Agregar(ClienteCreateDto clienteDto);
        Result Editar(ClienteUpdateDto clienteDto);
        Result Borrar(ClienteDeleteDto clienteDto);

        Result<ResultadoPaginacionDto<ClienteListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            bool? filtroActivo = null, string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo = null, string? textoBuscar = null);
    }
}

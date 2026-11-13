using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.FormaDePago;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface IFormaDePagoServicio
    {
        Result<FormaDePagoUpdateDto> ObtenerParaEditar(int id);
        Result<FormaDePagoDeleteDto> ObtenerParaBorrar(int id);

        Result<int> Agregar(FormaDePagoCreateDto dto);
        Result Editar(FormaDePagoUpdateDto dto);
        Result Borrar(FormaDePagoDeleteDto dto);

        Result<ResultadoPaginacionDto<FormaDePagoListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            bool? filtroActivo = null, string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo = null, string? textoBuscar = null);
    }
}

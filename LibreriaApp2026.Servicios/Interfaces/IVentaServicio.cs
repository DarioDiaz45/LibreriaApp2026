using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Venta;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface IVentaServicio
    {
        Result<ResultadoPaginacionDto<VentaListDto>> ObtenerPaginado(
            int pagina, int cantidadPorPagina, string? textoBuscar = null);
        Result<VentaDetailDto> ObtenerPorId(int ventaId);
        Result<int> Agregar(VentaCreateDto ventaDto);
        Result Facturar(int ventaId);
        Result AnularVenta(int ventaId);
        Result<List<ClienteComboDto>> ObtenerClientes();
        Result<List<FormaDePagoComboDto>> ObtenerFormasDePago();
        Result<List<LibroVentaDto>> ObtenerLibrosParaVenta();
    }
}

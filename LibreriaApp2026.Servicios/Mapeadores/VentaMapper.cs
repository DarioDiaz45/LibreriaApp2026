using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.Venta;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public static class VentaMapper
    {
        public static VentaListDto ToListDto(this Venta venta)
        {
            return new VentaListDto
            {
                VentaId = venta.VentaId,
                FechaVenta = DateOnly.FromDateTime(venta.FechaVenta),
                Cliente = $"{venta.Cliente.Apellido}, {venta.Cliente.Nombre}",
                Total = venta.TotalVenta,
                EstadoVenta = venta.EstadoVenta
            };
        }

        public static VentaDetailDto ToDetailDto(this Venta venta)
        {
            return new VentaDetailDto
            {
                VentaId = venta.VentaId,
                FechaVenta = DateOnly.FromDateTime(venta.FechaVenta),
                Cliente = $"{venta.Cliente.Apellido}, {venta.Cliente.Nombre}",
                FormaDePago = venta.FormaDePago.Nombre,
                Total = venta.TotalVenta,
                EstadoVenta = venta.EstadoVenta,
                DetalleVentas = venta.Detalles.Select(d => d.ToDto()).ToList()
            };
        }
    }
}

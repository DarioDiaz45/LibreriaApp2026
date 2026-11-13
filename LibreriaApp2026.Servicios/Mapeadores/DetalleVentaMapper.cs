using LibreriaApp2026.Entidades;
using LibreriaApp2026.Entidades.TipoLibro;
using LibreriaApp2026.Servicios.DTOs.DetalleVenta;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public static class DetalleVentaMapper
    {
        public static DetalleVentaDto ToDto(this DetalleVenta detalle)
        {
            return new DetalleVentaDto
            {
                LibroId = detalle.LibroId,
                Libro = detalle.Libro.Titulo,
                Precio = detalle.Precio,
                Cantidad = detalle.Cantidad,
                Stock = (detalle.Libro as LibroFisico)?.Stock
            };
        }
    }
}

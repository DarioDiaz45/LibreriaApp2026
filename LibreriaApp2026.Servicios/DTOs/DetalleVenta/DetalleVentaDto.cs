using System.ComponentModel;

namespace LibreriaApp2026.Servicios.DTOs.DetalleVenta
{
    public class DetalleVentaDto
    {
        public int LibroId { get; set; }
        public string Libro { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        [Browsable(false)]
        public int? Stock { get; set; }   

        public decimal Subtotal => Precio * Cantidad;
    }
}

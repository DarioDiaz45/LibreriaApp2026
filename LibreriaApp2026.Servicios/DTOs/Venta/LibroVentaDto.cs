namespace LibreriaApp2026.Servicios.DTOs.Venta
{
    public class LibroVentaDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public decimal Precio { get; set; }
        public int? Stock { get; set; }
    }
}

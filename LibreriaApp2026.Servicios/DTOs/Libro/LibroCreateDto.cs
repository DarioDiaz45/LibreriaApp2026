namespace LibreriaApp2026.Servicios.DTOs.Libro
{
    public class LibroCreateDto
    {
        public TipoLibro Tipo { get; set; }

        // Datos comunes
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int AnioPublicacion { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; } = true;
        public int EditorialId { get; set; }
        public List<int> AutoresIds { get; set; } = new();
        public List<int> TemasIds { get; set; } = new();

        // Solo libro físico
        public string? ISBN { get; set; }
        public int Stock { get; set; }

        // Solo libro digital
        public string? Identificador { get; set; }
        public string? Formato { get; set; }
        public long TamanoArchivo { get; set; }
        public string? UrlDescarga { get; set; }
    }
}

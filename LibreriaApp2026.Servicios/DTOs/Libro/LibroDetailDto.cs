namespace LibreriaApp2026.Servicios.DTOs.Libro
{
    public class LibroDetailDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int AnioPublicacion { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
        public string Editorial { get; set; } = null!;
        public List<string> Autores { get; set; } = new();
        public List<string> Temas { get; set; } = new();

        // Solo libro físico
        public string? ISBN { get; set; }
        public int? Stock { get; set; }

        // Solo libro digital
        public string? Identificador { get; set; }
        public string? Formato { get; set; }
        public long? TamanoArchivo { get; set; }
        public string? UrlDescarga { get; set; }
    }
}

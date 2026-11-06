using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaApp2026.Servicios.DTOs.Libro
{
    public class LibroListDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public string Codigo { get; set; } = null!;   
        public string Titulo { get; set; } = null!;
        public int AnioPublicacion { get; set; }
        public decimal Precio { get; set; }
        public int? Stock { get; set; }               
        public bool Activo { get; set; }
        public string Editorial { get; set; } = null!;
        public string Autores { get; set; } = null!;
        public string Temas { get; set; } = null!;
    }
}

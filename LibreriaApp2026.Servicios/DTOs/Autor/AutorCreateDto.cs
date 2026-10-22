namespace LibreriaApp2026.Servicios.DTOs.Autor
{
    public class AutorCreateDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; } = null!;
        
    }
}

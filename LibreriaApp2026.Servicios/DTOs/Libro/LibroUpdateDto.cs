namespace LibreriaApp2026.Servicios.DTOs.Libro
{
    public class LibroUpdateDto:LibroCreateDto
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}

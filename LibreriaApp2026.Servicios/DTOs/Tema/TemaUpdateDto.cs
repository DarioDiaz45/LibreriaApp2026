namespace LibreriaApp2026.Servicios.DTOs.Tema
{
    public class TemaUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}

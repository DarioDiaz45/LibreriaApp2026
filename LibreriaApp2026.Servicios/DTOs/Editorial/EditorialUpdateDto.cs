namespace LibreriaApp2026.Servicios.DTOs.Editorial
{
    public class EditorialUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string PaisOrigen { get; set; } = null!;
        public byte[] RowVersion { get; set; } = null!;
        public bool Activo { get; set; } = true;
    }
}

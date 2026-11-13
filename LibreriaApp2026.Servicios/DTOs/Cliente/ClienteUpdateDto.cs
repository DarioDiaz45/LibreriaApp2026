namespace LibreriaApp2026.Servicios.DTOs.Cliente
{
    public class ClienteUpdateDto
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public bool Activo { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}

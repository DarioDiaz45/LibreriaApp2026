namespace LibreriaApp2026.Servicios.DTOs.FormaDePago
{
    public class FormaDePagoUpdateDto
    {
        public int FormaDePagoId { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}

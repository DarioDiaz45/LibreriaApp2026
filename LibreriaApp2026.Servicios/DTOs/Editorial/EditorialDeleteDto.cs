using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaApp2026.Servicios.DTOs.Editorial
{
    public class EditorialDeleteDto
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}

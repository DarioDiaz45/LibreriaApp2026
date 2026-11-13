using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.FormaDePago;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public static class FormaDePagoMapper
    {
        public static FormaDePagoListDto ToListDto(FormaDePago f) => new()
        {
            FormaDePagoId = f.FormaDePagoId,
            Nombre = f.Nombre,
            Activo = f.Activo
        };

        public static FormaDePago ToEntidadCreate(FormaDePagoCreateDto dto) => new()
        {
            Nombre = dto.Nombre,
            Activo = dto.Activo
        };

        public static FormaDePago ToEntidadUpdate(FormaDePagoUpdateDto dto) => new()
        {
            FormaDePagoId = dto.FormaDePagoId,
            Nombre = dto.Nombre,
            Activo = dto.Activo,
            RowVersion = dto.RowVersion
        };

        public static FormaDePagoUpdateDto ToUpdateDto(FormaDePago f) => new()
        {
            FormaDePagoId = f.FormaDePagoId,
            Nombre = f.Nombre,
            Activo = f.Activo,
            RowVersion = f.RowVersion
        };

        public static FormaDePagoDeleteDto ToDeleteDto(FormaDePago f) => new()
        {
            FormaDePagoId = f.FormaDePagoId,
            RowVersion = f.RowVersion
        };
    }
}

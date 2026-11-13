using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.Cliente;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public static class ClienteMapper
    {
        public static ClienteListDto ToListDto(Cliente c) => new()
        {
            ClienteId = c.ClienteId,
            Nombre = c.Nombre,
            Apellido = c.Apellido,
            Telefono = c.Telefono,
            Email = c.Email,
            Activo = c.Activo
        };

        public static Cliente ToEntidadCreate(ClienteCreateDto dto) => new()
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Telefono = dto.Telefono,
            Email = dto.Email,
            Activo = dto.Activo
        };

        public static Cliente ToEntidadUpdate(ClienteUpdateDto dto) => new()
        {
            ClienteId = dto.ClienteId,
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Telefono = dto.Telefono,
            Email = dto.Email,
            Activo = dto.Activo,
            RowVersion = dto.RowVersion
        };

        public static ClienteUpdateDto ToUpdateDto(Cliente c) => new()
        {
            ClienteId = c.ClienteId,
            Nombre = c.Nombre,
            Apellido = c.Apellido,
            Telefono = c.Telefono,
            Email = c.Email,
            Activo = c.Activo,
            RowVersion = c.RowVersion
        };

        public static ClienteDeleteDto ToDeleteDto(Cliente c) => new()
        {
            ClienteId = c.ClienteId,
            RowVersion = c.RowVersion
        };
    }
}

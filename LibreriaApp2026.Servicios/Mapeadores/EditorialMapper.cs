using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.Editorial;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public class EditorialMapper
    {
        public static EditorialListDto ToEditorialListDto(Editorial editorial)
        {
            return new EditorialListDto
            {
                Id = editorial.Id,
                Nombre = editorial.Nombre,
                PaisOrigen = editorial.PaisOrigen
            };
        }

        public static Editorial ToEditorial(EditorialCreateDto dto)
        {
            return new Editorial(dto.Nombre, dto.PaisOrigen);
        }

        public static Editorial ToEditorial(EditorialUpdateDto dto)
        {
            return new Editorial
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                PaisOrigen = dto.PaisOrigen
            };
        }
    }
}

using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.Editorial;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public class EditorialMapper
    {
        public static EditorialListDto ToListDto(Editorial editorial)
        {
            return new EditorialListDto
            {
                Id = editorial.Id,
                Nombre = editorial.Nombre,
                PaisOrigen = editorial.PaisOrigen,
                Activo = editorial.Activo
            };
        }
        public static Editorial ToEntidad(EditorialCreateDto editorialDto)
        {
            return new Editorial(editorialDto.Nombre, editorialDto.PaisOrigen) { Activo = editorialDto.Activo };
        }
        public static Editorial ToEntidad(EditorialUpdateDto editorialDto)
        {
            return new Editorial
            {
                Id = editorialDto.Id,
                Nombre = editorialDto.Nombre,
                PaisOrigen = editorialDto.PaisOrigen
            };
        }
        public static EditorialDeleteDto ToDeleteDto(Editorial editorial)
        {
            return new EditorialDeleteDto
            {
                Id = editorial.Id,
                RowVersion = editorial.RowVersion

            };
        }


        public static Editorial ToEntidadCreate(EditorialCreateDto editorialDto)
        {
            return new Editorial
            {
                Nombre = editorialDto.Nombre,
                PaisOrigen = editorialDto.PaisOrigen
            };
        }
        public static Editorial ToEntidadUpdate(EditorialUpdateDto editorialDto)
        {
            return new Editorial
            {
                Id = editorialDto.Id,
                Nombre = editorialDto.Nombre,
                PaisOrigen = editorialDto.PaisOrigen,
                Activo = editorialDto.Activo,
                RowVersion = editorialDto.RowVersion
            };
        }

        public static EditorialUpdateDto ToUpdateDto(Editorial editorial)
        {
            return new EditorialUpdateDto
            {
                Id = editorial.Id,
                Nombre = editorial.Nombre,
                PaisOrigen = editorial.PaisOrigen,
                RowVersion = editorial.RowVersion,
                Activo = editorial.Activo
            };
        }

        public static EditorialDeleteDto ToDeleteDtoEditorial(Editorial editorial)
        {
            return new EditorialDeleteDto
            {
                Id = editorial.Id,
                RowVersion = editorial.RowVersion

            };
        }

    }
}

using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.Autor;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public class AutorMapper
    {
        public static AutorListDto ToListDto(Autor autor)
        {
            return new AutorListDto
            {
                Id = autor.Id,
                Nombre = autor.Nombre,
                Apellido = autor.Apellido,
                FechaNacimiento = autor.FechaNacimiento,
                Nacionalidad = autor.Nacionalidad
            };
        }

        public static Autor ToEntidadCreate(AutorCreateDto dto)
        {
            return new Autor
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                FechaNacimiento = dto.FechaNacimiento,
                Nacionalidad = dto.Nacionalidad
            };
        }

        public static Autor ToEntidadUpdate(AutorUpdateDto dto)
        {
            return new Autor
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                FechaNacimiento = dto.FechaNacimiento,
                Nacionalidad = dto.Nacionalidad,
                RowVersion = dto.RowVersion
            };
        }

        public static AutorUpdateDto ToUpdateDto(Autor autor)
        {
            return new AutorUpdateDto
            {
                Id = autor.Id,
                Nombre = autor.Nombre,
                Apellido = autor.Apellido,
                FechaNacimiento = autor.FechaNacimiento,
                Nacionalidad = autor.Nacionalidad,
                RowVersion = autor.RowVersion
            };
        }

        public static AutorDeleteDto ToDeleteDto(Autor autor)
        {
            return new AutorDeleteDto
            {
                Id = autor.Id,
                RowVersion = autor.RowVersion
            };
        }
    }
}

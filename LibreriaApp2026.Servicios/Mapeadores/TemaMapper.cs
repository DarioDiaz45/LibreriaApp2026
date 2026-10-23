using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.Tema;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public class TemaMapper
    {
        public static TemaListDto ToListDto(Tema tema)
        {
            return new TemaListDto
            {
                Id = tema.Id,
                Nombre = tema.Nombre,
                Descripcion = tema.Descripcion
            };
        }

        public static Tema ToEntidadCreate(TemaCreateDto dto)
        {
            return new Tema
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };
        }

        public static Tema ToEntidadUpdate(TemaUpdateDto dto)
        {
            return new Tema
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                RowVersion = dto.RowVersion
            };
        }

        public static TemaUpdateDto ToUpdateDto(Tema tema)
        {
            return new TemaUpdateDto
            {
                Id = tema.Id,
                Nombre = tema.Nombre,
                Descripcion = tema.Descripcion,
                RowVersion = tema.RowVersion
            };
        }

        public static TemaDeleteDto ToDeleteDto(Tema tema)
        {
            return new TemaDeleteDto
            {
                Id = tema.Id,
                RowVersion = tema.RowVersion
            };
        }
    }
}

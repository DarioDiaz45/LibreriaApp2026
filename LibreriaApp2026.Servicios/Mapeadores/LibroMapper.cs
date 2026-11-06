using LibreriaApp2026.Entidades;
using LibreriaApp2026.Entidades.TipoLibro;
using LibreriaApp2026.Servicios.DTOs.Libro;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public class LibroMapper
    {
        public static LibroListDto ToListDto(Libro libro)
        {
            var dto = new LibroListDto
            {
                Id = libro.Id,
                Tipo = libro.TipoDescripcion,
                Titulo = libro.Titulo,
                AnioPublicacion = libro.AnioPublicacion,
                Precio = libro.Precio,
                Activo = libro.Activo,
                Editorial = libro.Editorial?.Nombre ?? "",
                Autores = string.Join("; ", libro.Autores
                    .OrderBy(a => a.Apellido)
                    .Select(a => $"{a.Apellido}, {a.Nombre}")),
                Temas = string.Join("; ", libro.Temas
                    .OrderBy(t => t.Nombre)
                    .Select(t => t.Nombre))
            };

            switch (libro)
            {
                case LibroFisico fisico:
                    dto.Codigo = fisico.ISBN;
                    dto.Stock = fisico.Stock;
                    break;
                case LibroDigital digital:
                    dto.Codigo = digital.Identificador;
                    break;
            }

            return dto;
        }

       
        public static Libro ToEntidadCreate(LibroCreateDto dto)
        {
            Libro libro;

            if (dto.Tipo == TipoLibro.Fisico)
            {
                libro = new LibroFisico
                {
                    ISBN = dto.ISBN!,
                    Stock = dto.Stock
                };
            }
            else
            {
                libro = new LibroDigital
                {
                    Identificador = dto.Identificador!,
                    Formato = dto.Formato!,
                    TamanoArchivo = dto.TamanoArchivo,
                    UrlDescarga = dto.UrlDescarga!
                };
            }

            AplicarDatosComunes(libro, dto);
            return libro;
        }

       
        public static void AplicarCambios(Libro libro, LibroUpdateDto dto)
        {
            AplicarDatosComunes(libro, dto);

            switch (libro)
            {
                case LibroFisico fisico:
                    fisico.ISBN = dto.ISBN!;
                    fisico.Stock = dto.Stock;
                    break;
                case LibroDigital digital:
                    digital.Identificador = dto.Identificador!;
                    digital.Formato = dto.Formato!;
                    digital.TamanoArchivo = dto.TamanoArchivo;
                    digital.UrlDescarga = dto.UrlDescarga!;
                    break;
            }
        }

        public static LibroUpdateDto ToUpdateDto(Libro libro)
        {
            var dto = new LibroUpdateDto
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Descripcion = libro.Descripcion,
                AnioPublicacion = libro.AnioPublicacion,
                Precio = libro.Precio,
                Activo = libro.Activo,
                EditorialId = libro.EditorialId,
                AutoresIds = libro.Autores.Select(a => a.Id).ToList(),
                TemasIds = libro.Temas.Select(t => t.Id).ToList(),
                RowVersion = libro.RowVersion
            };

            switch (libro)
            {
                case LibroFisico fisico:
                    dto.Tipo = TipoLibro.Fisico;
                    dto.ISBN = fisico.ISBN;
                    dto.Stock = fisico.Stock;
                    break;
                case LibroDigital digital:
                    dto.Tipo = TipoLibro.Digital;
                    dto.Identificador = digital.Identificador;
                    dto.Formato = digital.Formato;
                    dto.TamanoArchivo = digital.TamanoArchivo;
                    dto.UrlDescarga = digital.UrlDescarga;
                    break;
            }

            return dto;
        }

        public static LibroDeleteDto ToDeleteDto(Libro libro)
        {
            return new LibroDeleteDto
            {
                Id = libro.Id,
                RowVersion = libro.RowVersion
            };
        }

        private static void AplicarDatosComunes(Libro libro, LibroCreateDto dto)
        {
            libro.Titulo = dto.Titulo;
            libro.Descripcion = dto.Descripcion;
            libro.AnioPublicacion = dto.AnioPublicacion;
            libro.Precio = dto.Precio;
            libro.Activo = dto.Activo;
            libro.EditorialId = dto.EditorialId;
        }
        public static LibroDetailDto ToDetalleDto(Libro libro)
        {
            var dto = new LibroDetailDto
            {
                Id = libro.Id,
                Tipo = libro.TipoDescripcion,
                Titulo = libro.Titulo,
                Descripcion = libro.Descripcion,
                AnioPublicacion = libro.AnioPublicacion,
                Precio = libro.Precio,
                Activo = libro.Activo,
                Editorial = libro.Editorial?.Nombre ?? "",
                Autores = libro.Autores
                    .OrderBy(a => a.Apellido).ThenBy(a => a.Nombre)
                    .Select(a => $"{a.Apellido}, {a.Nombre}")
                    .ToList(),
                Temas = libro.Temas
                    .OrderBy(t => t.Nombre)
                    .Select(t => t.Nombre)
                    .ToList()
            };

            switch (libro)
            {
                case LibroFisico fisico:
                    dto.ISBN = fisico.ISBN;
                    dto.Stock = fisico.Stock;
                    break;
                case LibroDigital digital:
                    dto.Identificador = digital.Identificador;
                    dto.Formato = digital.Formato;
                    dto.TamanoArchivo = digital.TamanoArchivo;
                    dto.UrlDescarga = digital.UrlDescarga;
                    break;
            }

            return dto;
        }
    }
}

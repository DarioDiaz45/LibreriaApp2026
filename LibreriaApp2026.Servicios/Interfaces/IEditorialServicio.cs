using LibreriaApp2026.Servicios.DTOs.Editorial;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface IEditorialServicio
    {
        List<EditorialListDto> ObtenerTodas();
        void Guardar(EditorialCreateDto editorialDto);
        void Editar(EditorialUpdateDto editorialDto);
        void Borrar(int id);
        bool Existe(EditorialCreateDto editorialDto);
    }
}

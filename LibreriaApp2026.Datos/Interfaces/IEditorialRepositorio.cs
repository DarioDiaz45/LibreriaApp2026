using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IEditorialRepositorio : IRepositorioGenerico<Editorial>
    {

        bool TieneLibrosAsociados(int editorialId);

    }
}

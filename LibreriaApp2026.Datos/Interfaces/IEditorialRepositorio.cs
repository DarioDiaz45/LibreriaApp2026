using LibreriaApp2026.Entidades;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IEditorialRepositorio : IRepositorioGenerico<Editorial>
    {

        bool TieneLibrosAsociados(int editorialId);
        int ObtenerPosicionRegistro(int seleccionadoId,
           Expression<Func<Editorial, bool>>? filtrarPor = null);

    }
}

using LibreriaApp2026.Entidades;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface ITemaRepositorio : IRepositorioGenerico<Tema>
    {
        bool TieneLibrosAsociados(int temaId);
        void Borrar(int id, byte[] rowVersion);
        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Tema, bool>>? filtrarPor = null);
    }
}

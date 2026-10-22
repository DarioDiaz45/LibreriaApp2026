using LibreriaApp2026.Entidades;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IAutorRepositorio : IRepositorioGenerico<Autor>
    {
        bool TieneLibrosAsociados(int autorId);
        void Borrar(int id, byte[] rowVersion);
        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Autor, bool>>? filtrarPor = null);
    }
}

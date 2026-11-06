using LibreriaApp2026.Entidades;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface ILibroRepositorio:IRepositorioGenerico<Libro>
    {
        Libro? ObtenerConRelaciones(int id);
        void EstablecerRowVersion(Libro libro, byte[] rowVersion);
        void Borrar(int id, byte[] rowVersion);
        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Libro, bool>>? filtrarPor = null);
    }
}

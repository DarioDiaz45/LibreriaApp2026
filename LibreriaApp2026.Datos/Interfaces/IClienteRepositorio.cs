using LibreriaApp2026.Entidades;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IClienteRepositorio : IRepositorioGenerico<Cliente> 
    {
        bool TieneVentasAsociadas(int clienteId);
        void Borrar(int id, byte[] rowVersion);
        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Cliente, bool>>? filtrarPor = null);
    }
}

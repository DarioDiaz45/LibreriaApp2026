using LibreriaApp2026.Entidades;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IFormaDePagoRepositorio : IRepositorioGenerico<FormaDePago>
    {
        bool TieneVentasAsociadas(int formaDePagoId);
        void Borrar(int id, byte[] rowVersion);
        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<FormaDePago, bool>>? filtrarPor = null);
    }
}

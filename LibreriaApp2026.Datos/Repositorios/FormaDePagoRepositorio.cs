using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class FormaDePagoRepositorio : RepositorioGenerico<FormaDePago>, IFormaDePagoRepositorio
    {
        private readonly LibreriaDbContext _dbContext;

        public FormaDePagoRepositorio(LibreriaDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public bool TieneVentasAsociadas(int formaDePagoId)
        {
            return _dbContext.Ventas.Any(v => v.FormaDePagoId == formaDePagoId);
        }

        public void Borrar(int id, byte[] rowVersion)
        {
            var entidad = ObtenerPorId(id)
                ?? throw new KeyNotFoundException();
            _dbContext.Entry(entidad).Property(f => f.RowVersion).OriginalValue = rowVersion;
            dbSet.Remove(entidad);
        }

       
        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<FormaDePago, bool>>? filtrarPor = null)
        {
            var seleccionado = ObtenerPorId(seleccionadoId);
            if (seleccionado is null) return 0;

            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }

            return query.Count(f => string.Compare(f.Nombre, seleccionado.Nombre) <= 0);
        }
    }
}

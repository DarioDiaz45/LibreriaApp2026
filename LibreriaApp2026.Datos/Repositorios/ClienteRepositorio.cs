using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class ClienteRepositorio : RepositorioGenerico<Cliente>, IClienteRepositorio
    {
        private readonly LibreriaDbContext _dbContext;

        public ClienteRepositorio(LibreriaDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public bool TieneVentasAsociadas(int clienteId)
        {
            return _dbContext.Ventas.Any(v => v.ClienteId == clienteId);
        }

        public void Borrar(int id, byte[] rowVersion)
        {
            var entidad = ObtenerPorId(id)
                ?? throw new KeyNotFoundException();
            _dbContext.Entry(entidad).Property(c => c.RowVersion).OriginalValue = rowVersion;
            dbSet.Remove(entidad);
        }

       
        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Cliente, bool>>? filtrarPor = null)
        {
            var seleccionado = ObtenerPorId(seleccionadoId);
            if (seleccionado is null) return 0;

            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }

            return query.Count(c =>
                string.Compare(c.Apellido, seleccionado.Apellido) < 0 ||
                (c.Apellido == seleccionado.Apellido &&
                 string.Compare(c.Nombre, seleccionado.Nombre) <= 0));
        }
    }
}

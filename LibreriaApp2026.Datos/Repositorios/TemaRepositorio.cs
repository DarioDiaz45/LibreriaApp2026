using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class TemaRepositorio : RepositorioGenerico<Tema>, ITemaRepositorio
    {
        private readonly LibreriaDbContext _dbContext;

        public TemaRepositorio(LibreriaDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public bool TieneLibrosAsociados(int temaId)
        {
            return _dbContext.Libros.Any(l => l.Temas.Any(t => t.Id == temaId));
        }

        public void Borrar(int id, byte[] rowVersion)
        {
            var entidad = ObtenerPorId(id)
                ?? throw new KeyNotFoundException();
            _dbContext.Entry(entidad).Property(t => t.RowVersion).OriginalValue = rowVersion;
            dbSet.Remove(entidad);
        }

        
        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Tema, bool>>? filtrarPor = null)
        {
            var seleccionado = ObtenerPorId(seleccionadoId);
            if (seleccionado is null) return 0;

            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }

            return query.Count(t => string.Compare(t.Nombre, seleccionado.Nombre) <= 0);
        }
    }
}

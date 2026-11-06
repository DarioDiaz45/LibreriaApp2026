using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class LibroRepositorio : RepositorioGenerico<Libro>, ILibroRepositorio
    {
        private readonly LibreriaDbContext _dbContext;

        public LibroRepositorio(LibreriaDbContext context) : base(context)
        {
            _dbContext = context;
        }

       
        public Libro? ObtenerConRelaciones(int id)
        {
            return _dbContext.Libros
                .Include(l => l.Autores)
                .Include(l => l.Temas)
                .FirstOrDefault(l => l.Id == id);
        }

        public void EstablecerRowVersion(Libro libro, byte[] rowVersion)
        {
            _dbContext.Entry(libro).Property(l => l.RowVersion).OriginalValue = rowVersion;
        }

        public void Borrar(int id, byte[] rowVersion)
        {
            var entidad = ObtenerPorId(id)
                ?? throw new KeyNotFoundException();
            _dbContext.Entry(entidad).Property(l => l.RowVersion).OriginalValue = rowVersion;
            dbSet.Remove(entidad);
        }

       
        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Libro, bool>>? filtrarPor = null)
        {
            var seleccionado = ObtenerPorId(seleccionadoId);
            if (seleccionado is null) return 0;

            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }

            return query.Count(l => string.Compare(l.Titulo, seleccionado.Titulo) <= 0);
        }
    }
}

using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class AutorRepositorio : RepositorioGenerico<Autor>, IAutorRepositorio
    {
        private readonly LibreriaDbContext _dbContext;

        public AutorRepositorio(LibreriaDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public bool TieneLibrosAsociados(int autorId)
        {
            return _dbContext.Libros.Any(l => l.Autores.Any(a => a.Id == autorId));
        }

        public void Borrar(int id, byte[] rowVersion)
        {
            var entidad = ObtenerPorId(id)
                ?? throw new KeyNotFoundException();
            _dbContext.Entry(entidad).Property(a => a.RowVersion).OriginalValue = rowVersion;
            dbSet.Remove(entidad);
        }


        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Autor, bool>>? filtrarPor = null)
        {
            var seleccionado = ObtenerPorId(seleccionadoId);
            if (seleccionado is null) return 0;

            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }

            return query.Count(a =>
                string.Compare(a.Apellido, seleccionado.Apellido) < 0 ||
                (a.Apellido == seleccionado.Apellido &&
                 string.Compare(a.Nombre, seleccionado.Nombre) <= 0));
        }
    }
}


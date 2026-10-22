using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class EditorialRepositorio : RepositorioGenerico<Editorial>, IEditorialRepositorio
    {
        private readonly LibreriaDbContext _dbContext;

        public EditorialRepositorio(LibreriaDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public int ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Editorial, bool>>? filtrarPor = null)
        {
            var tipoEnDb = ObtenerPorId(seleccionadoId);
            if (tipoEnDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query
                .Count(tb => string.Compare(tb.Nombre, tipoEnDb.Nombre) <= 0);
        }

        public bool TieneLibrosAsociados(int editorialId)
        {
            
            return _dbContext.Libros.Any(l => l.EditorialId == editorialId);
        }
    }
}

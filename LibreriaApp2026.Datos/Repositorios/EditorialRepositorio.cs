using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class EditorialRepositorio : RepositorioGenerico<Editorial>, IEditorialRepositorio
    {
        private readonly LibreriaDbContext _dbContext;

        public EditorialRepositorio(LibreriaDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public bool TieneLibrosAsociados(int editorialId)
        {
            
            return _dbContext.Libros.Any(l => l.EditorialId == editorialId);
        }
    }
}

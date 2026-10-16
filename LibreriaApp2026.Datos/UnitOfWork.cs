using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Datos.Repositorios;

namespace LibreriaApp2026.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibreriaDbContext _context;

        public IEditorialRepositorio Editoriales { get; private set; }
        // public IAutorRepositorio Autores { get; private set; }
        // public ITemaRepositorio Temas { get; private set; }
        // public ILibroRepositorio Libros { get; private set; }

        public UnitOfWork(LibreriaDbContext context)
        {
            _context = context;
            Editoriales = new EditorialRepositorio(_context);
            // Autores = new AutorRepositorio(_context);
            // Temas = new TemaRepositorio(_context);
            // Libros = new LibroRepositorio(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

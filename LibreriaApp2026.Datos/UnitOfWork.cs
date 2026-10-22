using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Datos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApp2026.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibreriaDbContext _context;

        public IEditorialRepositorio Editoriales { get; private set; }
        public IAutorRepositorio Autores { get; private set; }
        // public ITemaRepositorio Temas { get; private set; }
        // public ILibroRepositorio Libros { get; private set; }

        public UnitOfWork(LibreriaDbContext context)
        {
            _context = context;
            Editoriales = new EditorialRepositorio(_context);
            Autores = new AutorRepositorio(_context);
            // Temas = new TemaRepositorio(_context);
            // Libros = new LibroRepositorio(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void RollBack()
        {
            foreach (var item in _context.ChangeTracker.Entries())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.State = EntityState.Unchanged;
                        item.CurrentValues.SetValues(item.OriginalValues);
                        break;
                    case EntityState.Added:
                        item.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        item.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}

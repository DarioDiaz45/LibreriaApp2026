using LibreriaApp2026.Datos.Interfaces;

namespace LibreriaApp2026.Datos
{
    public interface IUnitOfWork
    {

        IEditorialRepositorio Editoriales { get; }
        IAutorRepositorio Autores { get; }
        // ITemaRepositorio Temas { get; }
        // ILibroRepositorio Libros { get; }

        int SaveChanges();
        void RollBack();

    }
}

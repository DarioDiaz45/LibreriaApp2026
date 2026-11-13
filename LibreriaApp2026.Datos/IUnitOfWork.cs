using LibreriaApp2026.Datos.Interfaces;

namespace LibreriaApp2026.Datos
{
    public interface IUnitOfWork
    {

        IEditorialRepositorio Editoriales { get; }
        IAutorRepositorio Autores { get; }
        ITemaRepositorio Temas { get; }
        ILibroRepositorio Libros { get; }
        IClienteRepositorio Clientes { get; }
        IFormaDePagoRepositorio FormasDePago { get; }
        IVentaRepositorio Ventas { get; }

        int SaveChanges();
        void RollBack();

    }
}

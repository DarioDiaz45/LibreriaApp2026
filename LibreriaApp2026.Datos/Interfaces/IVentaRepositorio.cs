using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IVentaRepositorio
    {
        Venta? ObtenerPorId(int ventaId, bool tracked = false);
        (List<Venta> lista, int cantidadRegistros) ObtenerPagina(
            int paginaActual, int cantidadPorPagina, string? textoBuscar = null);
        void Agregar(Venta venta);
    }
}

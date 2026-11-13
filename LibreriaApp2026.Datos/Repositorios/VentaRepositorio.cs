using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly LibreriaDbContext _context;

        public VentaRepositorio(LibreriaDbContext context)
        {
            _context = context;
        }

        public void Agregar(Venta venta)
        {
            _context.Ventas.Add(venta);
        }

        public (List<Venta> lista, int cantidadRegistros) ObtenerPagina(
            int paginaActual, int cantidadPorPagina, string? textoBuscar = null)
        {
            IQueryable<Venta> query = _context.Ventas
                .Include(v => v.Cliente)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(textoBuscar))
            {
                query = query.Where(v =>
                    v.Cliente.Nombre.Contains(textoBuscar) ||
                    v.Cliente.Apellido.Contains(textoBuscar));
            }

            var cantidad = query.Count();
            var lista = query
                .OrderByDescending(v => v.FechaVenta)
                .Skip(cantidadPorPagina * (paginaActual - 1))
                .Take(cantidadPorPagina)
                .ToList();

            return (lista, cantidad);
        }


        public Venta? ObtenerPorId(int ventaId, bool tracked = false)
        {
            IQueryable<Venta> query = _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.FormaDePago)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Libro);

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return query.FirstOrDefault(v => v.VentaId == ventaId);
        }
    }
}

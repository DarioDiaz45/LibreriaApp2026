using LibreriaApp2026.Datos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        protected readonly LibreriaDbContext _context;
        internal DbSet<T> dbSet;

        public RepositorioGenerico(LibreriaDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public virtual List<T> ObtenerTodos()
        {
            return dbSet.ToList();
        }

        public virtual IQueryable<T> Query()
        {
            return dbSet.AsQueryable();
        }

        public virtual T? ObtenerPorId(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Agregar(T entidad)
        {
            dbSet.Add(entidad);
        }

        public virtual void Editar(T entidad, int id)
        {
           
            dbSet.Update(entidad);
        }

        public virtual void Borrar(int id)
        {
            var entidad = ObtenerPorId(id);
            if (entidad != null)
            {
                dbSet.Remove(entidad);
            }
        }

        public virtual (List<T> lista, int totalRegistros) ObtenerPagina(
            int pagina,
            int cantidad,
            Func<IQueryable<T>, IOrderedQueryable<T>> ordenarPor,
            Expression<Func<T, bool>>? filtrarPor = null,
            Func<IQueryable<T>, IQueryable<T>>? incluir = null)
        {
            IQueryable<T> query = dbSet;

            
            if (filtrarPor != null)
            {
                query = query.Where(filtrarPor);
            }

           
            if (incluir != null)
            {
                query = incluir(query);
            }

            
            int totalRegistros = query.Count();

            
            if (ordenarPor != null)
            {
                query = ordenarPor(query);
            }

            
            var lista = query.Skip((pagina - 1) * cantidad).Take(cantidad).ToList();

            return (lista, totalRegistros);
        }
    }
}

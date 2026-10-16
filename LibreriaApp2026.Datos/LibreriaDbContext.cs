using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApp2026.Datos
{
    public class LibreriaDbContext : DbContext
    {
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Libro> Libros { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object value = optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LibreriaApp2026;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibreriaDbContext).Assembly);
        }

    }
}

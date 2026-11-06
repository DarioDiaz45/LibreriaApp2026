using LibreriaApp2026.Entidades.TipoLibro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class LibroFisicoEntityTypeConfiguration : IEntityTypeConfiguration<LibroFisico>
    {
        public void Configure(EntityTypeBuilder<LibroFisico> builder)
        {
            builder.ToTable("LibrosFisicos");

            builder.Property(l => l.ISBN)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(l => l.ISBN)
                .IsUnique();

            builder.Property(l => l.Stock)
                .IsRequired();
        }
    }
}

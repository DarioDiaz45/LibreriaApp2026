using LibreriaApp2026.Entidades.TipoLibro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class LibroDigitalEntityTypeConfiguration : IEntityTypeConfiguration<LibroDigital>
    {
        public void Configure(EntityTypeBuilder<LibroDigital> builder)
        {
            builder.ToTable("LibrosDigitales");

            builder.Property(l => l.Identificador)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(l => l.Identificador)
                .IsUnique();

            builder.Property(l => l.Formato)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(l => l.TamanoArchivo)
                .IsRequired();

            builder.Property(l => l.UrlDescarga)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}

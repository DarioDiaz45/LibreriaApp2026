using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class AutorEntityTypeConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Apellido)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Nacionalidad)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.FechaNacimiento)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}

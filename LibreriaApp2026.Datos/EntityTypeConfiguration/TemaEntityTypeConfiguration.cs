using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class TemaEntityTypeConfiguration : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder.ToTable("Temas");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Descripcion)
                .HasMaxLength(255)
                .IsRequired(false); 
        }
    }
}

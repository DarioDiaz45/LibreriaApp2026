using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class EditorialEntityTypeConfiguration : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.ToTable("Editoriales");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.PaisOrigen)
                .HasMaxLength(50)
                .IsRequired();


            builder.HasMany(e => e.Libros)
                .WithOne(l => l.Editorial)
                .HasForeignKey(l => l.EditorialId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(e => e.RowVersion)
                 .IsRowVersion();
            builder.Property(e => e.Activo)
            .IsRequired();
        }
    }
}

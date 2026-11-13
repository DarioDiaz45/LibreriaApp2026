using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class FormaDePagoEntityTypeConfiguration : IEntityTypeConfiguration<FormaDePago>
    {
        public void Configure(EntityTypeBuilder<FormaDePago> builder)
        {
            builder.ToTable("FormasDePago");
            builder.HasKey(f => f.FormaDePagoId);

            builder.Property(f => f.Nombre).HasMaxLength(50).IsRequired();
            builder.HasIndex(f => f.Nombre).IsUnique();
            builder.Property(f => f.Activo).HasDefaultValue(true);
            builder.Property(f => f.RowVersion).IsRowVersion();
        }
    }
}

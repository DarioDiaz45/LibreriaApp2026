using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.ClienteId);

            builder.Property(c => c.Nombre).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Apellido).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Telefono).HasMaxLength(30);
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.Activo).HasDefaultValue(true);
            builder.Property(c => c.RowVersion).IsRowVersion();
        }
    }
}

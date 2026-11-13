using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class DetalleVentaEntityTypeConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVentas");


            builder.HasKey(d => new { d.VentaId, d.LibroId });

            builder.Property(d => d.Precio)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(d => d.Cantidad).IsRequired();


            builder.Ignore(d => d.Subtotal);

            builder.HasOne(d => d.Libro)
                .WithMany(l => l.DetalleVentas)
                .HasForeignKey(d => d.LibroId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}

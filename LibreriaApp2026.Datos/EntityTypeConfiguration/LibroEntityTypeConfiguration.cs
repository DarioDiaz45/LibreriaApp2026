using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class LibroEntityTypeConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            
            builder.UseTptMappingStrategy();
            builder.ToTable("Libros");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Titulo)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(l => l.Descripcion)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(l => l.Precio)
                .HasPrecision(12, 2)
                .IsRequired();

            builder.Property(l => l.AnioPublicacion)
                .IsRequired();

            builder.Property(l => l.Activo)
                .IsRequired();

            builder.Property(l => l.RowVersion)
                .IsRowVersion();

            builder.HasMany(l => l.Autores)
                .WithMany(a => a.Libros)
                .UsingEntity("AutorLibro");

            builder.HasMany(l => l.Temas)
                .WithMany(t => t.Libros)
                .UsingEntity("LibroTema");
        }
    }
}

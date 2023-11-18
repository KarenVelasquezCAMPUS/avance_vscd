using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class DocumentoConfiguration : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.ToTable("documento");

            builder.HasKey(e => e.IdDocumento);
            builder.Property(e => e.IdDocumento)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(f => f.IdNumeracionFk)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(f => f.IdEstadoFk)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(p => p.Numero)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(p => p.Fecha)
            .HasColumnType("DATE")
            .IsRequired();

            builder.Property(p => p.Base)
            .HasColumnType("DECIMAL")
            .IsRequired();

            builder.Property(p => p.Impuesto)
            .HasColumnType("DECIMAL")
            .IsRequired();

            // LLaves Foraneas
            builder.HasOne(p => p.Numeracion)
            .WithMany(p => p.Documentos)
            .HasForeignKey(p => p.IdNumeracionFk);

            builder.HasOne(p => p.Estado)
            .WithMany(p => p.Documentos)
            .HasForeignKey(p => p.IdEstadoFk);
        }
    }
}
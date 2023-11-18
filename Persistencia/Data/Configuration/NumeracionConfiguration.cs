using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class NumeracionConfiguration : IEntityTypeConfiguration<Numeracion>
    {
        public void Configure(EntityTypeBuilder<Numeracion> builder)
        {
            builder.ToTable("numeracion");

            builder.HasKey(e => e.IdNumeracion);
            builder.Property(e => e.IdNumeracion)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(f => f.IdTipoDocumentoFk)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(f => f.IdEmpresaFk)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(p => p.Prefijo)
            .HasColumnType("VARCHAR")
            .HasMaxLength(8)
            .IsRequired();

            builder.Property(p => p.ConsecutivoInicial)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(p => p.ConsecutivoFinal)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(p => p.VigenciaInicial)
            .HasColumnType("DATE")
            .IsRequired();

            builder.Property(p => p.VigenciaFinal)
            .HasColumnType("DATE")
            .IsRequired();

            // LLaves Foraneas
            builder.HasOne(p => p.TipoDocumento)
            .WithMany(p => p.Numeraciones)
            .HasForeignKey(p => p.IdTipoDocumentoFk);

            builder.HasOne(p => p.Empresa)
            .WithMany(p => p.Numeraciones)
            .HasForeignKey(p => p.IdEmpresaFk);
        }
    }
}
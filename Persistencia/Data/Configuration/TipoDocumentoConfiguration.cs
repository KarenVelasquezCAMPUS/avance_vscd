using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {
            builder.ToTable("tipodocumento");

            builder.HasKey(e => e.IdTipoDocumento);
            builder.Property(e => e.IdTipoDocumento)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(p => p.Descripcion)
            .HasColumnType("VARCHAR")
            .HasMaxLength(256)
            .IsRequired();
        }
    }
}
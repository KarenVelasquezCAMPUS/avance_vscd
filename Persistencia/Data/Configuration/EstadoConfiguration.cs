using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("estado");

            builder.HasKey(e => e.IdEstado);
            builder.Property(e => e.IdEstado)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(p => p.Descripcion)
            .HasColumnType("VARCHAR")
            .HasMaxLength(256)
            .IsRequired();

            builder.Property(p => p.Exitoso)
            .HasColumnType("BIT")
            .IsRequired();
        }
    }
}
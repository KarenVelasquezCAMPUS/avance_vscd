using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("empresa");

            builder.HasKey(e => e.IdEmpresa);
            builder.Property(e => e.IdEmpresa)
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(p => p.Identificacion)
            .HasColumnType("VARCHAR")
            .HasMaxLength(16)
            .IsRequired();

            builder.Property(p => p.RazonSocial)
            .HasColumnType("VARCHAR")
            .HasMaxLength(256)
            .IsRequired();
        }
    }
}
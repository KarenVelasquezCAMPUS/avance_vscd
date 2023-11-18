﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(ApiAvancevscdContext))]
    partial class ApiAvancevscdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entities.Documento", b =>
                {
                    b.Property<int>("IdDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    b.Property<decimal>("Base")
                        .HasColumnType("DECIMAL");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATE");

                    b.Property<int>("IdEstadoFk")
                        .HasColumnType("INT");

                    b.Property<int>("IdNumeracionFk")
                        .HasColumnType("INT");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("DECIMAL");

                    b.Property<int>("Numero")
                        .HasColumnType("INT");

                    b.HasKey("IdDocumento");

                    b.HasIndex("IdEstadoFk");

                    b.HasIndex("IdNumeracionFk");

                    b.ToTable("documento", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Empresa", b =>
                {
                    b.Property<int>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR");

                    b.HasKey("IdEmpresa");

                    b.ToTable("empresa", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR");

                    b.Property<ulong>("Exitoso")
                        .HasColumnType("BIT");

                    b.HasKey("IdEstado");

                    b.ToTable("estado", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Numeracion", b =>
                {
                    b.Property<int>("IdNumeracion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    b.Property<int>("ConsecutivoFinal")
                        .HasColumnType("INT");

                    b.Property<int>("ConsecutivoInicial")
                        .HasColumnType("INT");

                    b.Property<int>("IdEmpresaFk")
                        .HasColumnType("INT");

                    b.Property<int>("IdTipoDocumentoFk")
                        .HasColumnType("INT");

                    b.Property<string>("Prefijo")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("VigenciaFinal")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("VigenciaInicial")
                        .HasColumnType("DATE");

                    b.HasKey("IdNumeracion");

                    b.HasIndex("IdEmpresaFk");

                    b.HasIndex("IdTipoDocumentoFk");

                    b.ToTable("numeracion", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoDocumento", b =>
                {
                    b.Property<int>("IdTipoDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR");

                    b.HasKey("IdTipoDocumento");

                    b.ToTable("tipodocumento", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Documento", b =>
                {
                    b.HasOne("Dominio.Entities.Estado", "Estado")
                        .WithMany("Documentos")
                        .HasForeignKey("IdEstadoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Numeracion", "Numeracion")
                        .WithMany("Documentos")
                        .HasForeignKey("IdNumeracionFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Numeracion");
                });

            modelBuilder.Entity("Dominio.Entities.Numeracion", b =>
                {
                    b.HasOne("Dominio.Entities.Empresa", "Empresa")
                        .WithMany("Numeraciones")
                        .HasForeignKey("IdEmpresaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.TipoDocumento", "TipoDocumento")
                        .WithMany("Numeraciones")
                        .HasForeignKey("IdTipoDocumentoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("Dominio.Entities.Empresa", b =>
                {
                    b.Navigation("Numeraciones");
                });

            modelBuilder.Entity("Dominio.Entities.Estado", b =>
                {
                    b.Navigation("Documentos");
                });

            modelBuilder.Entity("Dominio.Entities.Numeracion", b =>
                {
                    b.Navigation("Documentos");
                });

            modelBuilder.Entity("Dominio.Entities.TipoDocumento", b =>
                {
                    b.Navigation("Numeraciones");
                });
#pragma warning restore 612, 618
        }
    }
}

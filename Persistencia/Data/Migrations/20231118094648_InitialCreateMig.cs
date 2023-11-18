using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Identificacion = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RazonSocial = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.IdEmpresa);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exitoso = table.Column<ulong>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.IdEstado);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipodocumento",
                columns: table => new
                {
                    IdTipoDocumento = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipodocumento", x => x.IdTipoDocumento);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "numeracion",
                columns: table => new
                {
                    IdNumeracion = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdTipoDocumentoFk = table.Column<int>(type: "INT", nullable: false),
                    IdEmpresaFk = table.Column<int>(type: "INT", nullable: false),
                    Prefijo = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsecutivoInicial = table.Column<int>(type: "INT", nullable: false),
                    ConsecutivoFinal = table.Column<int>(type: "INT", nullable: false),
                    VigenciaInicial = table.Column<DateTime>(type: "DATE", nullable: false),
                    VigenciaFinal = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_numeracion", x => x.IdNumeracion);
                    table.ForeignKey(
                        name: "FK_numeracion_empresa_IdEmpresaFk",
                        column: x => x.IdEmpresaFk,
                        principalTable: "empresa",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_numeracion_tipodocumento_IdTipoDocumentoFk",
                        column: x => x.IdTipoDocumentoFk,
                        principalTable: "tipodocumento",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "documento",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdNumeracionFk = table.Column<int>(type: "INT", nullable: false),
                    IdEstadoFk = table.Column<int>(type: "INT", nullable: false),
                    Numero = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATE", nullable: false),
                    Base = table.Column<decimal>(type: "DECIMAL(65,30)", nullable: false),
                    Impuesto = table.Column<decimal>(type: "DECIMAL(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento", x => x.IdDocumento);
                    table.ForeignKey(
                        name: "FK_documento_estado_IdEstadoFk",
                        column: x => x.IdEstadoFk,
                        principalTable: "estado",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documento_numeracion_IdNumeracionFk",
                        column: x => x.IdNumeracionFk,
                        principalTable: "numeracion",
                        principalColumn: "IdNumeracion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_documento_IdEstadoFk",
                table: "documento",
                column: "IdEstadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_documento_IdNumeracionFk",
                table: "documento",
                column: "IdNumeracionFk");

            migrationBuilder.CreateIndex(
                name: "IX_numeracion_IdEmpresaFk",
                table: "numeracion",
                column: "IdEmpresaFk");

            migrationBuilder.CreateIndex(
                name: "IX_numeracion_IdTipoDocumentoFk",
                table: "numeracion",
                column: "IdTipoDocumentoFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documento");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "numeracion");

            migrationBuilder.DropTable(
                name: "empresa");

            migrationBuilder.DropTable(
                name: "tipodocumento");
        }
    }
}

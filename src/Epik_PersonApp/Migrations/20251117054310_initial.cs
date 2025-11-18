using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Epik_PersonApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposIdentificacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposIdentificacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    TipoIdentificacionId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_TiposIdentificacion_TipoIdentificacionId",
                        column: x => x.TipoIdentificacionId,
                        principalTable: "TiposIdentificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposIdentificacion",
                columns: new[] { "Id", "Codigo", "CreatedAt", "Descripcion", "IsActive", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0c0785e7-4863-48f7-ada7-ba819cf91e2d"), "CC", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cédula de Ciudadanía", true, null },
                    { new Guid("0c0785e7-4863-48f7-ada7-cfe3b67df097"), "RC", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registro Civil", true, null },
                    { new Guid("1a8d3e2f-4f23-4b0e-9d29-44eae48bbaa1"), "PA", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasaporte", true, null },
                    { new Guid("2bfe05a9-df9a-4932-8a6a-511d6cccd8e6"), "TI", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarjeta de Identidad", true, null },
                    { new Guid("3c2f1f66-9a65-44fc-b1ea-34ac2eab2553"), "CE", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cédula de Extranjería", true, null },
                    { new Guid("4e1c1499-8b27-4c65-b9f3-6a1918e842db"), "PEP", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Permiso Especial de Permanencia (PEP)", true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_NumeroIdentificacion",
                table: "Personas",
                column: "Identificacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TipoIdentificacionId",
                table: "Personas",
                column: "TipoIdentificacionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "TiposIdentificacion");
        }
    }
}

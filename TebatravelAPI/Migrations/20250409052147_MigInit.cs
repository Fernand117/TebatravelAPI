using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TebatravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarreraEntities",
                columns: table => new
                {
                    CarreraId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreCarrera = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraId", x => x.CarreraId);
                });

            migrationBuilder.CreateTable(
                name: "EscuelaEntities",
                columns: table => new
                {
                    EscuelaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreEscuela = table.Column<string>(type: "text", nullable: false),
                    Clave = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscuelaId", x => x.EscuelaId);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoEntities",
                columns: table => new
                {
                    AlummnoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Paterno = table.Column<string>(type: "text", nullable: false),
                    Materno = table.Column<string>(type: "text", nullable: false),
                    NumCelular = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CarreraId = table.Column<int>(type: "integer", nullable: false),
                    EscuelaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoId", x => x.AlummnoId);
                    table.ForeignKey(
                        name: "FK_AlumnoEntities_CarreraEntities_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "CarreraEntities",
                        principalColumn: "CarreraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoEntities_EscuelaEntities_EscuelaId",
                        column: x => x.EscuelaId,
                        principalTable: "EscuelaEntities",
                        principalColumn: "EscuelaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoEntities_CarreraId",
                table: "AlumnoEntities",
                column: "CarreraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoEntities_EscuelaId",
                table: "AlumnoEntities",
                column: "EscuelaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoEntities");

            migrationBuilder.DropTable(
                name: "CarreraEntities");

            migrationBuilder.DropTable(
                name: "EscuelaEntities");
        }
    }
}

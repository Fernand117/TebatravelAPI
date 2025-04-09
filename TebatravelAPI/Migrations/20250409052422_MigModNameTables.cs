using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TebatravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigModNameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoEntities_CarreraEntities_CarreraId",
                table: "AlumnoEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoEntities_EscuelaEntities_EscuelaId",
                table: "AlumnoEntities");

            migrationBuilder.RenameTable(
                name: "EscuelaEntities",
                newName: "Escuela");

            migrationBuilder.RenameTable(
                name: "CarreraEntities",
                newName: "Carrera");

            migrationBuilder.RenameTable(
                name: "AlumnoEntities",
                newName: "Alumno");

            migrationBuilder.RenameIndex(
                name: "IX_AlumnoEntities_EscuelaId",
                table: "Alumno",
                newName: "IX_Alumno_EscuelaId");

            migrationBuilder.RenameIndex(
                name: "IX_AlumnoEntities_CarreraId",
                table: "Alumno",
                newName: "IX_Alumno_CarreraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Carrera_CarreraId",
                table: "Alumno",
                column: "CarreraId",
                principalTable: "Carrera",
                principalColumn: "CarreraId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Escuela_EscuelaId",
                table: "Alumno",
                column: "EscuelaId",
                principalTable: "Escuela",
                principalColumn: "EscuelaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Carrera_CarreraId",
                table: "Alumno");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Escuela_EscuelaId",
                table: "Alumno");

            migrationBuilder.RenameTable(
                name: "Escuela",
                newName: "EscuelaEntities");

            migrationBuilder.RenameTable(
                name: "Carrera",
                newName: "CarreraEntities");

            migrationBuilder.RenameTable(
                name: "Alumno",
                newName: "AlumnoEntities");

            migrationBuilder.RenameIndex(
                name: "IX_Alumno_EscuelaId",
                table: "AlumnoEntities",
                newName: "IX_AlumnoEntities_EscuelaId");

            migrationBuilder.RenameIndex(
                name: "IX_Alumno_CarreraId",
                table: "AlumnoEntities",
                newName: "IX_AlumnoEntities_CarreraId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoEntities_CarreraEntities_CarreraId",
                table: "AlumnoEntities",
                column: "CarreraId",
                principalTable: "CarreraEntities",
                principalColumn: "CarreraId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoEntities_EscuelaEntities_EscuelaId",
                table: "AlumnoEntities",
                column: "EscuelaId",
                principalTable: "EscuelaEntities",
                principalColumn: "EscuelaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

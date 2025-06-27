using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TebatravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigInitialTres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Carrera_CarreraId",
                table: "Alumno");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Escuela_EscuelaId",
                table: "Alumno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AsistenciaId",
                table: "Asistencia");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_CarreraId",
                table: "Alumno");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_EscuelaId",
                table: "Alumno");

            migrationBuilder.RenameColumn(
                name: "AlummnoId",
                table: "Alumno",
                newName: "AlumnoId");

            migrationBuilder.AddColumn<int>(
                name: "AlumnoId",
                table: "Escuela",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlumnoId",
                table: "Carrera",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asistencia",
                table: "Asistencia",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Escuela_AlumnoId",
                table: "Escuela",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_AlumnoId",
                table: "Carrera",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_CarreraId",
                table: "Alumno",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_EscuelaId",
                table: "Alumno",
                column: "EscuelaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Carrera_CarreraId",
                table: "Alumno",
                column: "CarreraId",
                principalTable: "Carrera",
                principalColumn: "CarreraId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Escuela_EscuelaId",
                table: "Alumno",
                column: "EscuelaId",
                principalTable: "Escuela",
                principalColumn: "EscuelaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrera_Alumno_AlumnoId",
                table: "Carrera",
                column: "AlumnoId",
                principalTable: "Alumno",
                principalColumn: "AlumnoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Escuela_Alumno_AlumnoId",
                table: "Escuela",
                column: "AlumnoId",
                principalTable: "Alumno",
                principalColumn: "AlumnoId",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Carrera_Alumno_AlumnoId",
                table: "Carrera");

            migrationBuilder.DropForeignKey(
                name: "FK_Escuela_Alumno_AlumnoId",
                table: "Escuela");

            migrationBuilder.DropIndex(
                name: "IX_Escuela_AlumnoId",
                table: "Escuela");

            migrationBuilder.DropIndex(
                name: "IX_Carrera_AlumnoId",
                table: "Carrera");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asistencia",
                table: "Asistencia");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_CarreraId",
                table: "Alumno");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_EscuelaId",
                table: "Alumno");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "Escuela");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "Carrera");

            migrationBuilder.RenameColumn(
                name: "AlumnoId",
                table: "Alumno",
                newName: "AlummnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AsistenciaId",
                table: "Asistencia",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_CarreraId",
                table: "Alumno",
                column: "CarreraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_EscuelaId",
                table: "Alumno",
                column: "EscuelaId",
                unique: true);

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
    }
}

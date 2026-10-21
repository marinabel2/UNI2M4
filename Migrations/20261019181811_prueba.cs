using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica2EF2M4.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaConocimiento",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaConocimiento", x => x.IdArea);
                });

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    IdAsignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Creditos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.IdAsignatura);
                });

            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    IdCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdArea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.IdCarrera);
                    table.ForeignKey(
                        name: "FK_Carreras_AreaConocimiento_IdArea",
                        column: x => x.IdArea,
                        principalTable: "AreaConocimiento",
                        principalColumn: "IdArea",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carnet = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCarrera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IdEstudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Carreras_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carreras",
                        principalColumn: "IdCarrera",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstudianteAsignatura",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    IdAsignatura = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                    Aprobada = table.Column<bool>(type: "bit", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudianteAsignatura", x => new { x.IdEstudiante, x.IdAsignatura });
                    table.ForeignKey(
                        name: "FK_EstudianteAsignatura_Asignatura_IdAsignatura",
                        column: x => x.IdAsignatura,
                        principalTable: "Asignatura",
                        principalColumn: "IdAsignatura",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstudianteAsignatura_Estudiantes_IdEstudiante",
                        column: x => x.IdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_Codigo",
                table: "Asignatura",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carreras_IdArea",
                table: "Carreras",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteAsignatura_IdAsignatura",
                table: "EstudianteAsignatura",
                column: "IdAsignatura");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_Carnet",
                table: "Estudiantes",
                column: "Carnet",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_IdCarrera",
                table: "Estudiantes",
                column: "IdCarrera");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudianteAsignatura");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "AreaConocimiento");
        }
    }
}

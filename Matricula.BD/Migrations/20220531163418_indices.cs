using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaseModelado1.BD.Migrations
{
    public partial class indices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecialidadId",
                table: "Medicos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumMatricula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadId",
                table: "Medicos",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_EspecialidadId",
                table: "Matriculas",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "MatriculaMedicoIdEspecialidadId_UQ",
                table: "Matriculas",
                columns: new[] { "MedicoId", "EspecialidadId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadId",
                table: "Medicos",
                column: "EspecialidadId",
                principalTable: "Especialidades",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadId",
                table: "Medicos");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_EspecialidadId",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "EspecialidadId",
                table: "Medicos");
        }
    }
}

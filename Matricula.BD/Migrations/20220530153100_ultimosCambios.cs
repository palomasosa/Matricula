using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaseModelado1.BD.Migrations
{
    public partial class ultimosCambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Medicos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "Medicos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Medicos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomEspecialidad",
                table: "Especialidades",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Especialidades",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Especialidades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "MedicoDNI_UQ",
                table: "Medicos",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EspecialidadCodigo_UQ",
                table: "Especialidades",
                column: "Codigo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "MedicoDNI_UQ",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "EspecialidadCodigo_UQ",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Especialidades");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "NomEspecialidad",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);
        }
    }
}

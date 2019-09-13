using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myFirstAzureWebApp.Data.Migrations
{
    public partial class agregarHorario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaHora",
                table: "Horario");

            migrationBuilder.AddColumn<string>(
                name: "Dia",
                table: "Horario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hora",
                table: "Horario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dia",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "Hora",
                table: "Horario");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHora",
                table: "Horario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace myFirstAzureWebApp.Data.Migrations
{
    public partial class EstudiantesPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Estudiante",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Estudiante");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace myFirstAzureWebApp.Data.Migrations
{
    public partial class encuentros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcadorLocal",
                table: "Encuentros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MarcadorVisitante",
                table: "Encuentros",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarcadorLocal",
                table: "Encuentros");

            migrationBuilder.DropColumn(
                name: "MarcadorVisitante",
                table: "Encuentros");
        }
    }
}

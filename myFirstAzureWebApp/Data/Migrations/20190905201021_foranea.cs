using Microsoft.EntityFrameworkCore.Migrations;

namespace myFirstAzureWebApp.Data.Migrations
{
    public partial class foranea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EscuelaID",
                table: "Encuentros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Encuentros_EscuelaID",
                table: "Encuentros",
                column: "EscuelaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Encuentros_Escuela_EscuelaID",
                table: "Encuentros",
                column: "EscuelaID",
                principalTable: "Escuela",
                principalColumn: "EscuelaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encuentros_Escuela_EscuelaID",
                table: "Encuentros");

            migrationBuilder.DropIndex(
                name: "IX_Encuentros_EscuelaID",
                table: "Encuentros");

            migrationBuilder.DropColumn(
                name: "EscuelaID",
                table: "Encuentros");
        }
    }
}

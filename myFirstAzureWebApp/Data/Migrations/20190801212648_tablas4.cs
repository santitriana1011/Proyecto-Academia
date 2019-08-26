using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myFirstAzureWebApp.Data.Migrations
{
    public partial class tablas4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Traspaso",
                columns: table => new
                {
                    TraspasoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstudianteID = table.Column<int>(nullable: false),
                    EscuelaID = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Novedades = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traspaso", x => x.TraspasoID);
                    table.ForeignKey(
                        name: "FK_Traspaso_Escuela_EscuelaID",
                        column: x => x.EscuelaID,
                        principalTable: "Escuela",
                        principalColumn: "EscuelaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Traspaso_Estudiante_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Estudiante",
                        principalColumn: "EstudianteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Traspaso_EscuelaID",
                table: "Traspaso",
                column: "EscuelaID");

            migrationBuilder.CreateIndex(
                name: "IX_Traspaso_EstudianteID",
                table: "Traspaso",
                column: "EstudianteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Traspaso");
        }
    }
}

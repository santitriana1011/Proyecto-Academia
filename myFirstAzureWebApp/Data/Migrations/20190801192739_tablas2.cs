using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myFirstAzureWebApp.Data.Migrations
{
    public partial class tablas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mensualidad",
                columns: table => new
                {
                    MensualidadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcudienteID = table.Column<int>(nullable: false),
                    FechaPago = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<int>(nullable: false),
                    Mes = table.Column<string>(nullable: true),
                    Anio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensualidad", x => x.MensualidadID);
                    table.ForeignKey(
                        name: "FK_Mensualidad_Acudiente_AcudienteID",
                        column: x => x.AcudienteID,
                        principalTable: "Acudiente",
                        principalColumn: "AcudienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mensualidad_AcudienteID",
                table: "Mensualidad",
                column: "AcudienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mensualidad");
        }
    }
}

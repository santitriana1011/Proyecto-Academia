using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myFirstAzureWebApp.Data.Migrations
{
    public partial class tablas3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HojaDeVida",
                columns: table => new
                {
                    HojaDeVidaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoID = table.Column<int>(nullable: false),
                    Especialidad = table.Column<string>(nullable: true),
                    TiempoExperiencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HojaDeVida", x => x.HojaDeVidaID);
                    table.ForeignKey(
                        name: "FK_HojaDeVida_Empleado_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nomina",
                columns: table => new
                {
                    NominaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomina", x => x.NominaID);
                    table.ForeignKey(
                        name: "FK_Nomina_Empleado_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nomina_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NovedadMedica",
                columns: table => new
                {
                    NovedadMedicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstudianteID = table.Column<int>(nullable: false),
                    EmpleadoID = table.Column<int>(nullable: false),
                    FechaLesion = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovedadMedica", x => x.NovedadMedicaID);
                    table.ForeignKey(
                        name: "FK_NovedadMedica_Empleado_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NovedadMedica_Estudiante_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Estudiante",
                        principalColumn: "EstudianteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HojaDeVida_EmpleadoID",
                table: "HojaDeVida",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_EmpleadoID",
                table: "Nomina",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_ItemID",
                table: "Nomina",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_NovedadMedica_EmpleadoID",
                table: "NovedadMedica",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_NovedadMedica_EstudianteID",
                table: "NovedadMedica",
                column: "EstudianteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HojaDeVida");

            migrationBuilder.DropTable(
                name: "Nomina");

            migrationBuilder.DropTable(
                name: "NovedadMedica");
        }
    }
}

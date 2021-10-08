using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class AddingExp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experimentos",
                columns: table => new
                {
                    ExperimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    ExperimentoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experimentos", x => x.ExperimentoId);
                    table.ForeignKey(
                        name: "FK_Experimentos_Experimentos_ExperimentoId1",
                        column: x => x.ExperimentoId1,
                        principalTable: "Experimentos",
                        principalColumn: "ExperimentoId",
                        onDelete: ReferentialAction.Restrict);
                });

           

            migrationBuilder.CreateTable(
                name: "GuiaExperimentos",
                columns: table => new
                {
                    GuiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<int>(type: "int", nullable: false),
                    Instruccion = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<int>(type: "int", nullable: false),
                    ExperimentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuiaExperimentos", x => x.GuiaId);
                    table.ForeignKey(
                        name: "FK_GuiaExperimentos_Experimentos_ExperimentoId",
                        column: x => x.ExperimentoId,
                        principalTable: "Experimentos",
                        principalColumn: "ExperimentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_Experimentos_ExperimentoId1",
                table: "Experimentos",
                column: "ExperimentoId1");

            migrationBuilder.CreateIndex(
                name: "IX_GuiaExperimentos_ExperimentoId",
                table: "GuiaExperimentos",
                column: "ExperimentoId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuiaExperimentos");

            migrationBuilder.DropTable(
                name: "Experimentos");

        }
    }
}

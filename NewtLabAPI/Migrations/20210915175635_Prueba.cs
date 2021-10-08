using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class Prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PruebaExperimentos",
                columns: table => new
                {
                    PruebaExperimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    BancoPreguntaId = table.Column<int>(type: "int", nullable: true),
                    FechaTomado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalificacionObtenida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PruebaExperimentos", x => x.PruebaExperimentoId);
                    table.ForeignKey(
                        name: "FK_PruebaExperimentos_BancoPreguntas_BancoPreguntaId",
                        column: x => x.BancoPreguntaId,
                        principalTable: "BancoPreguntas",
                        principalColumn: "BancoPreguntaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PruebaExperimentos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PruebaExperimentos_BancoPreguntaId",
                table: "PruebaExperimentos",
                column: "BancoPreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_PruebaExperimentos_UserId",
                table: "PruebaExperimentos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PruebaExperimentos");
        }
    }
}

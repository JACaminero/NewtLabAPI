using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class PruebaRespuesta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PruebaRespuesta",
                columns: table => new
                {
                    PruebaRespuestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PEId = table.Column<int>(type: "int", nullable: false),
                    PreguntaId = table.Column<int>(type: "int", nullable: false),
                    RespuestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PruebaRespuesta", x => x.PruebaRespuestaId);
                    table.ForeignKey(
                        name: "FK_PruebaRespuesta_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "PreguntaId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PruebaRespuesta_PruebaExperimentos_PEId",
                        column: x => x.PEId,
                        principalTable: "PruebaExperimentos",
                        principalColumn: "PruebaExperimentoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PruebaRespuesta_Respuestas_RespuestaId",
                        column: x => x.RespuestaId,
                        principalTable: "Respuestas",
                        principalColumn: "RespuestaId",
                        onDelete: ReferentialAction.NoAction);
                });


            migrationBuilder.CreateIndex(
                name: "IX_PruebaRespuesta_PEId",
                table: "PruebaRespuesta",
                column: "PEId");

            migrationBuilder.CreateIndex(
                name: "IX_PruebaRespuesta_PreguntaId",
                table: "PruebaRespuesta",
                column: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_PruebaRespuesta_RespuestaId",
                table: "PruebaRespuesta",
                column: "RespuestaId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PruebaRespuesta");
        }
    }
}

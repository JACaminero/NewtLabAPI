using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class RekindledAnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPreguntas",
                columns: table => new
                {
                    TipoPreguntaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPreguntas", x => x.TipoPreguntaId);
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

            
            migrationBuilder.CreateTable(
                name: "BancoPreguntas",
                columns: table => new
                {
                    BancoPreguntaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TituloPublicado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExperimentoId = table.Column<int>(type: "int", nullable: false),
                    Publicado = table.Column<bool>(type: "bit", nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsOn = table.Column<bool>(type: "bit", nullable: false),
                    Instruccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoPreguntas", x => x.BancoPreguntaId);
                    table.ForeignKey(
                        name: "FK_BancoPreguntas_Experimentos_ExperimentoId",
                        column: x => x.ExperimentoId,
                        principalTable: "Experimentos",
                        principalColumn: "ExperimentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BancoPreguntas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    PreguntaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BancoPreguntaId = table.Column<int>(type: "int", nullable: false),
                    TP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPreguntaId = table.Column<int>(type: "int", nullable: false),
                    IsOn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.PreguntaId);
                    table.ForeignKey(
                        name: "FK_Preguntas_BancoPreguntas_BancoPreguntaId",
                        column: x => x.BancoPreguntaId,
                        principalTable: "BancoPreguntas",
                        principalColumn: "BancoPreguntaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preguntas_TipoPreguntas_TipoPreguntaId",
                        column: x => x.TipoPreguntaId,
                        principalTable: "TipoPreguntas",
                        principalColumn: "TipoPreguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PruebaExperimentos",
                columns: table => new
                {
                    PruebaExperimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BancoPreguntaId = table.Column<int>(type: "int", nullable: false),
                    FechaTomado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalificacionObtenida = table.Column<int>(type: "int", nullable: false),
                    CalificacionTotal = table.Column<int>(type: "int", nullable: false),
                    IsCerrada = table.Column<bool>(type: "bit", nullable: false),
                    Periodo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PruebaExperimentos", x => x.PruebaExperimentoId);
                    table.ForeignKey(
                        name: "FK_PruebaExperimentos_BancoPreguntas_BancoPreguntaId",
                        column: x => x.BancoPreguntaId,
                        principalTable: "BancoPreguntas",
                        principalColumn: "BancoPreguntaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PruebaExperimentos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    RespuestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsCorrecta = table.Column<bool>(type: "bit", nullable: false),
                    PreguntaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.RespuestaId);
                    table.ForeignKey(
                        name: "FK_Respuestas_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "PreguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_BancoPreguntas_ExperimentoId",
                table: "BancoPreguntas",
                column: "ExperimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_BancoPreguntas_UserId",
                table: "BancoPreguntas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GuiaExperimentos_ExperimentoId",
                table: "GuiaExperimentos",
                column: "ExperimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_BancoPreguntaId",
                table: "Preguntas",
                column: "BancoPreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_TipoPreguntaId",
                table: "Preguntas",
                column: "TipoPreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_PruebaExperimentos_BancoPreguntaId",
                table: "PruebaExperimentos",
                column: "BancoPreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_PruebaExperimentos_UserId",
                table: "PruebaExperimentos",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_PreguntaId",
                table: "Respuestas",
                column: "PreguntaId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuiaExperimentos");

            migrationBuilder.DropTable(
                name: "PruebaRespuesta");

            migrationBuilder.DropTable(
                name: "PruebaExperimentos");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "BancoPreguntas");

            migrationBuilder.DropTable(
                name: "TipoPreguntas");

            migrationBuilder.DropTable(
                name: "Experimentos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

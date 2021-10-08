using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class BancoPreg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experimentos_Experimentos_ExperimentoId1",
                table: "Experimentos");

            migrationBuilder.DropIndex(
                name: "IX_Experimentos_ExperimentoId1",
                table: "Experimentos");

            migrationBuilder.DropColumn(
                name: "ExperimentoId1",
                table: "Experimentos");

            migrationBuilder.CreateTable(
                name: "BancoPreguntas",
                columns: table => new
                {
                    BancoPreguntaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperimentoId = table.Column<int>(type: "int", nullable: false)
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
                });

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
                name: "Preguntas",
                columns: table => new
                {
                    PreguntaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<int>(type: "int", nullable: false),
                    BancoPreguntaId = table.Column<int>(type: "int", nullable: false),
                    TipoPreguntaId = table.Column<int>(type: "int", nullable: false)
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
                name: "Respuestas",
                columns: table => new
                {
                    RespuestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreguntaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puntuacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.RespuestaId);
                    table.ForeignKey(
                        name: "FK_Respuestas_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "PreguntaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BancoPreguntas_ExperimentoId",
                table: "BancoPreguntas",
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
                name: "IX_Respuestas_PreguntaId",
                table: "Respuestas",
                column: "PreguntaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "BancoPreguntas");

            migrationBuilder.DropTable(
                name: "TipoPreguntas");

            migrationBuilder.AddColumn<int>(
                name: "ExperimentoId1",
                table: "Experimentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experimentos_ExperimentoId1",
                table: "Experimentos",
                column: "ExperimentoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Experimentos_Experimentos_ExperimentoId1",
                table: "Experimentos",
                column: "ExperimentoId1",
                principalTable: "Experimentos",
                principalColumn: "ExperimentoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

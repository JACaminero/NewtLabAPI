using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class PlzLetItBeTheLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalificacionObtenidaReal",
                table: "PruebaExperimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CalifTotalPublicado",
                table: "BancoPreguntas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalificacionObtenidaReal",
                table: "PruebaExperimentos");

            migrationBuilder.DropColumn(
                name: "CalifTotalPublicado",
                table: "BancoPreguntas");
        }
    }
}

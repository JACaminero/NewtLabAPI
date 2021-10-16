using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class CalificacionTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isCerrada",
                table: "PruebaExperimentos",
                newName: "IsCerrada");

            migrationBuilder.AddColumn<int>(
                name: "CalificacionTotal",
                table: "PruebaExperimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalificacionTotal",
                table: "PruebaExperimentos");

            migrationBuilder.RenameColumn(
                name: "IsCerrada",
                table: "PruebaExperimentos",
                newName: "isCerrada");
        }
    }
}

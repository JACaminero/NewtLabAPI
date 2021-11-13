using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class Sesion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOn",
                table: "Sesions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOn",
                table: "Sesions");
        }
    }
}

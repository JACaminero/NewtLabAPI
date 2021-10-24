using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class Migrationa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grado",
                table: "Users",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grado",
                table: "Users");
        }
    }
}

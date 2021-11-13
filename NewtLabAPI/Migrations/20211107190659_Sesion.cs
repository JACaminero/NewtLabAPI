using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class Sesion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sesions",
                columns: table => new
                {
                    SesionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SesionNombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesions", x => x.SesionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sesions");
        }
    }
}

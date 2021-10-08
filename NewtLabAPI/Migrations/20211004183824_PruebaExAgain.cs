using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class PruebaExAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaLimite",
                table: "PruebaExperimentos");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "PruebaExperimentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaLimite",
                table: "BancoPreguntas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaLimite",
                table: "BancoPreguntas");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaLimite",
                table: "PruebaExperimentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "PruebaExperimentos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

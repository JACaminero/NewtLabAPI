using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtlabAPI.Migrations
{
    public partial class PruebaEx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PruebaExperimentos_BancoPreguntas_BancoPreguntaId",
                table: "PruebaExperimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_PruebaExperimentos_Users_UserId",
                table: "PruebaExperimentos");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PruebaExperimentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BancoPreguntaId",
                table: "PruebaExperimentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddColumn<bool>(
                name: "Publicado",
                table: "BancoPreguntas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_PruebaExperimentos_BancoPreguntas_BancoPreguntaId",
                table: "PruebaExperimentos",
                column: "BancoPreguntaId",
                principalTable: "BancoPreguntas",
                principalColumn: "BancoPreguntaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PruebaExperimentos_Users_UserId",
                table: "PruebaExperimentos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PruebaExperimentos_BancoPreguntas_BancoPreguntaId",
                table: "PruebaExperimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_PruebaExperimentos_Users_UserId",
                table: "PruebaExperimentos");

            migrationBuilder.DropColumn(
                name: "FechaLimite",
                table: "PruebaExperimentos");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "PruebaExperimentos");

            migrationBuilder.DropColumn(
                name: "Publicado",
                table: "BancoPreguntas");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PruebaExperimentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BancoPreguntaId",
                table: "PruebaExperimentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PruebaExperimentos_BancoPreguntas_BancoPreguntaId",
                table: "PruebaExperimentos",
                column: "BancoPreguntaId",
                principalTable: "BancoPreguntas",
                principalColumn: "BancoPreguntaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PruebaExperimentos_Users_UserId",
                table: "PruebaExperimentos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

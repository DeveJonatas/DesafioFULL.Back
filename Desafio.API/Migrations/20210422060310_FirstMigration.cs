using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<long>(type: "INTEGER", nullable: false),
                    NomeDevedor = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    CPFDevedor = table.Column<string>(type: "TEXT", nullable: true),
                    Juros = table.Column<float>(type: "REAL", precision: 10, scale: 2, nullable: false),
                    Multa = table.Column<float>(type: "REAL", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroParcela = table.Column<int>(type: "INTEGER", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Valor = table.Column<float>(type: "REAL", precision: 10, scale: 2, nullable: false),
                    IdTitulo = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_Titulos_IdTitulo",
                        column: x => x.IdTitulo,
                        principalTable: "Titulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_IdTitulo",
                table: "Parcelas",
                column: "IdTitulo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "Titulos");
        }
    }
}

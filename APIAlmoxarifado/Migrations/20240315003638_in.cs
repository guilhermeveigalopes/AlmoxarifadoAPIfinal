using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAlmoxarifado.Migrations
{
    public partial class @in : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benchmarking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MercadoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MercadoPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MercadoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MagazineTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MagazinePrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MagazineUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Melhor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benchmarking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    IdLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodRob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuRob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLog = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Processo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InfLog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.IdLog);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Benchmarking");

            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}

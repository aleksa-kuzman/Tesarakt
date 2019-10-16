using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tesarakt.Common.Models.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrupaProizvoda",
                columns: table => new
                {
                    GrupaId = table.Column<int>(nullable: false),
                    NazivGrupe = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedByUserId = table.Column<int>(nullable: false),
                    Active = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupaProizvoda", x => x.GrupaId);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ProizvodId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    NazivProizvoda = table.Column<string>(maxLength: 50, nullable: true),
                    CenaProizvoda = table.Column<double>(nullable: true),
                    GrupaId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedByUserId = table.Column<int>(nullable: false),
                    Active = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ProizvodId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupaProizvoda");

            migrationBuilder.DropTable(
                name: "Proizvod");
        }
    }
}

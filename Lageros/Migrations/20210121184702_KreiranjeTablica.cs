using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Lageros.Migrations
{
    public partial class KreiranjeTablica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Toner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZamjenaToner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrinterId = table.Column<int>(type: "int", nullable: false),
                    TonerId = table.Column<int>(type: "int", nullable: false),
                    DatumZamjene = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamjenaToner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZamjenaToner_Printeri_PrinterId",
                        column: x => x.PrinterId,
                        principalTable: "Printeri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZamjenaToner_Toner_TonerId",
                        column: x => x.TonerId,
                        principalTable: "Toner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZamjenaToner_PrinterId",
                table: "ZamjenaToner",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_ZamjenaToner_TonerId",
                table: "ZamjenaToner",
                column: "TonerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZamjenaToner");

            migrationBuilder.DropTable(
                name: "Toner");
        }
    }
}

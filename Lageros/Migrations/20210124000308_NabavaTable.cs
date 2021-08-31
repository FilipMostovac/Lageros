using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Lageros.Migrations
{
    public partial class NabavaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NabavaTonera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TonerId = table.Column<int>(type: "int", nullable: false),
                    DatumZamjene = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NabavaTonera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NabavaTonera_Toner_TonerId",
                        column: x => x.TonerId,
                        principalTable: "Toner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NabavaTonera_TonerId",
                table: "NabavaTonera",
                column: "TonerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NabavaTonera");
        }
    }
}

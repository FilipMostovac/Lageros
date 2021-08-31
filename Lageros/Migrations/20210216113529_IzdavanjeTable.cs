using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Lageros.Migrations
{
    public partial class IzdavanjeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Izdavanje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    LaptopId = table.Column<int>(type: "int", nullable: true),
                    MonitorId = table.Column<int>(type: "int", nullable: true),
                    PeriferijaId = table.Column<int>(type: "int", nullable: true),
                    DatumZamjene = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izdavanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Izdavanje_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izdavanje_Laptop_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Izdavanje_Monitor_MonitorId",
                        column: x => x.MonitorId,
                        principalTable: "Monitor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Izdavanje_Periferija_PeriferijaId",
                        column: x => x.PeriferijaId,
                        principalTable: "Periferija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Izdavanje_KorisnikId",
                table: "Izdavanje",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Izdavanje_LaptopId",
                table: "Izdavanje",
                column: "LaptopId");

            migrationBuilder.CreateIndex(
                name: "IX_Izdavanje_MonitorId",
                table: "Izdavanje",
                column: "MonitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Izdavanje_PeriferijaId",
                table: "Izdavanje",
                column: "PeriferijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Izdavanje");
        }
    }
}

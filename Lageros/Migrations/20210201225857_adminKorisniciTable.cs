using Microsoft.EntityFrameworkCore.Migrations;

namespace Lageros.Migrations
{
    public partial class adminKorisniciTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminKorisnikId",
                table: "ZamjenaToner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdminKorisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminKorisnik", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZamjenaToner_AdminKorisnikId",
                table: "ZamjenaToner",
                column: "AdminKorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_ZamjenaToner_AdminKorisnik_AdminKorisnikId",
                table: "ZamjenaToner",
                column: "AdminKorisnikId",
                principalTable: "AdminKorisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZamjenaToner_AdminKorisnik_AdminKorisnikId",
                table: "ZamjenaToner");

            migrationBuilder.DropTable(
                name: "AdminKorisnik");

            migrationBuilder.DropIndex(
                name: "IX_ZamjenaToner_AdminKorisnikId",
                table: "ZamjenaToner");

            migrationBuilder.DropColumn(
                name: "AdminKorisnikId",
                table: "ZamjenaToner");
        }
    }
}

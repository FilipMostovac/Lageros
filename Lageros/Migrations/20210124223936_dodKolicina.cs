using Microsoft.EntityFrameworkCore.Migrations;

namespace Lageros.Migrations
{
    public partial class dodKolicina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "NabavaTonera",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "NabavaTonera");
        }
    }
}

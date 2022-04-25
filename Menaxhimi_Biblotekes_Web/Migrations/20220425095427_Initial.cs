using Microsoft.EntityFrameworkCore.Migrations;

namespace Menaxhimi_Biblotekes_Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoriId",
                table: "Libri");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutoriId",
                table: "Libri",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

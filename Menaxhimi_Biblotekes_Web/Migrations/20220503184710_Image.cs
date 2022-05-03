using Microsoft.EntityFrameworkCore.Migrations;

namespace Menaxhimi_Biblotekes_Web.Migrations
{
    public partial class Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Libri");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Libri",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

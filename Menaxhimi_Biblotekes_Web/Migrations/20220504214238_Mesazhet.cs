using Microsoft.EntityFrameworkCore.Migrations;

namespace Menaxhimi_Biblotekes_Web.Migrations
{
    public partial class Mesazhet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mesazhet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesazhi = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PjesemarresiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesazhet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesazhet_Pjesemarresi_PjesemarresiId",
                        column: x => x.PjesemarresiId,
                        principalTable: "Pjesemarresi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesazhet_PjesemarresiId",
                table: "Mesazhet",
                column: "PjesemarresiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mesazhet");
        }
    }
}

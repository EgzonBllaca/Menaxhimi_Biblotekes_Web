using Microsoft.EntityFrameworkCore.Migrations;

namespace Menaxhimi_Biblotekes_Web.Migrations
{
    public partial class RemoveKategoriaLibri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KategoriaLibri");

            migrationBuilder.CreateIndex(
                name: "IX_Libri_KategoriaId",
                table: "Libri",
                column: "KategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Kategoria_KategoriaId",
                table: "Libri",
                column: "KategoriaId",
                principalTable: "Kategoria",
                principalColumn: "KategoriaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Kategoria_KategoriaId",
                table: "Libri");

            migrationBuilder.DropIndex(
                name: "IX_Libri_KategoriaId",
                table: "Libri");

            migrationBuilder.CreateTable(
                name: "KategoriaLibri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriaId = table.Column<int>(type: "int", nullable: false),
                    LibriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriaLibri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KategoriaLibri_Kategoria_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategoria",
                        principalColumn: "KategoriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategoriaLibri_Libri_LibriId",
                        column: x => x.LibriId,
                        principalTable: "Libri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KategoriaLibri_KategoriaId",
                table: "KategoriaLibri",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriaLibri_LibriId",
                table: "KategoriaLibri",
                column: "LibriId");
        }
    }
}

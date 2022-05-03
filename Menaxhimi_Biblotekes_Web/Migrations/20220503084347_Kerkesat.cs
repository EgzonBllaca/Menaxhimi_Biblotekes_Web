using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Menaxhimi_Biblotekes_Web.Migrations
{
    public partial class Kerkesat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PjesemarresiRoli");

            migrationBuilder.CreateTable(
                name: "KerkesatPerHuazim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibriId = table.Column<int>(type: "int", nullable: false),
                    PjesemarresiId = table.Column<int>(type: "int", nullable: false),
                    DataHuazimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AfatiKthimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataKthimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Verejtje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedByUserID = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KerkesatPerHuazim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KerkesatPerHuazim_Libri_LibriId",
                        column: x => x.LibriId,
                        principalTable: "Libri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KerkesatPerHuazim_Pjesemarresi_PjesemarresiId",
                        column: x => x.PjesemarresiId,
                        principalTable: "Pjesemarresi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pjesemarresi_RoliId",
                table: "Pjesemarresi",
                column: "RoliId");

            migrationBuilder.CreateIndex(
                name: "IX_KerkesatPerHuazim_LibriId",
                table: "KerkesatPerHuazim",
                column: "LibriId");

            migrationBuilder.CreateIndex(
                name: "IX_KerkesatPerHuazim_PjesemarresiId",
                table: "KerkesatPerHuazim",
                column: "PjesemarresiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pjesemarresi_Roli_RoliId",
                table: "Pjesemarresi",
                column: "RoliId",
                principalTable: "Roli",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pjesemarresi_Roli_RoliId",
                table: "Pjesemarresi");

            migrationBuilder.DropTable(
                name: "KerkesatPerHuazim");

            migrationBuilder.DropIndex(
                name: "IX_Pjesemarresi_RoliId",
                table: "Pjesemarresi");

            migrationBuilder.CreateTable(
                name: "PjesemarresiRoli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PjesemarresiId = table.Column<int>(type: "int", nullable: false),
                    RoliId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PjesemarresiRoli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PjesemarresiRoli_Pjesemarresi_PjesemarresiId",
                        column: x => x.PjesemarresiId,
                        principalTable: "Pjesemarresi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PjesemarresiRoli_Roli_RoliId",
                        column: x => x.RoliId,
                        principalTable: "Roli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PjesemarresiRoli_PjesemarresiId",
                table: "PjesemarresiRoli",
                column: "PjesemarresiId");

            migrationBuilder.CreateIndex(
                name: "IX_PjesemarresiRoli_RoliId",
                table: "PjesemarresiRoli",
                column: "RoliId");
        }
    }
}

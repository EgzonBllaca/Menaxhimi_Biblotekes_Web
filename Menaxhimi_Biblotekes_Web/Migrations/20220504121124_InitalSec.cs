using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Menaxhimi_Biblotekes_Web.Migrations
{
    public partial class InitalSec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserID",
                table: "Autori");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Autori");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Autori");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Autori");

            migrationBuilder.DropColumn(
                name: "LastUpdatedByUserID",
                table: "Autori");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "Autori");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Libri",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Libri",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserID",
                table: "Autori",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Autori",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Autori",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Autori",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LastUpdatedByUserID",
                table: "Autori",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Autori",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

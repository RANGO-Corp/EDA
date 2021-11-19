using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alere.Migrations
{
    public partial class RemovedUnusedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedUntil",
                table: "Tbl_Food");

            migrationBuilder.AlterColumn<bool>(
                name: "IsReserved",
                table: "Tbl_Food",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPerishable",
                table: "Tbl_Food",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsReserved",
                table: "Tbl_Food",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPerishable",
                table: "Tbl_Food",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedUntil",
                table: "Tbl_Food",
                type: "datetime2",
                nullable: true);
        }
    }
}

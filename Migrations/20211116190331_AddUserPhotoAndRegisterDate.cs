using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alere.Migrations
{
    public partial class AddUserPhotoAndRegisterDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tbl_User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Tbl_User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tbl_User");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Tbl_User");
        }
    }
}

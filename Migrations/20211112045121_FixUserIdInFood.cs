using Microsoft.EntityFrameworkCore.Migrations;

namespace Alere.Migrations
{
    public partial class FixUserIdInFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Food_Tbl_User_AnnouncedByUserUserId",
                table: "Tbl_Food");

            migrationBuilder.RenameColumn(
                name: "AnnouncedByUserUserId",
                table: "Tbl_Food",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Food_AnnouncedByUserUserId",
                table: "Tbl_Food",
                newName: "IX_Tbl_Food_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Food_Tbl_User_UserId",
                table: "Tbl_Food",
                column: "UserId",
                principalTable: "Tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Food_Tbl_User_UserId",
                table: "Tbl_Food");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tbl_Food",
                newName: "AnnouncedByUserUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Food_UserId",
                table: "Tbl_Food",
                newName: "IX_Tbl_Food_AnnouncedByUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Food_Tbl_User_AnnouncedByUserUserId",
                table: "Tbl_Food",
                column: "AnnouncedByUserUserId",
                principalTable: "Tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

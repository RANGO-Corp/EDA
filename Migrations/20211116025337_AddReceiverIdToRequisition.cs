using Microsoft.EntityFrameworkCore.Migrations;

namespace Alere.Migrations
{
    public partial class AddReceiverIdToRequisition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ReceiverId",
                table: "Tbl_Requisition",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Requisition_ReceiverId",
                table: "Tbl_Requisition",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Requisition_Tbl_User_ReceiverId",
                table: "Tbl_Requisition",
                column: "ReceiverId",
                principalTable: "Tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Requisition_Tbl_User_ReceiverId",
                table: "Tbl_Requisition");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Requisition_ReceiverId",
                table: "Tbl_Requisition");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Tbl_Requisition");
        }
    }
}

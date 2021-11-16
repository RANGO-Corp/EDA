using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alere.Migrations
{
    public partial class AddRequisitionPersistence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Requisition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requisition_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonorId = table.Column<long>(type: "bigint", nullable: false),
                    FoodId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Requisition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Requisition_Tbl_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Tbl_Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Requisition_Tbl_User_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Requisition_DonorId",
                table: "Tbl_Requisition",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Requisition_FoodId",
                table: "Tbl_Requisition",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Requisition");
        }
    }
}

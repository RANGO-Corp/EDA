using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alere.Migrations
{
    public partial class Reboot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Food",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReserved = table.Column<bool>(type: "bit", nullable: true),
                    ReservedUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPerishable = table.Column<bool>(type: "bit", nullable: true),
                    ManufacturedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Food_Tbl_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Requisition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requisition_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonorId = table.Column<long>(type: "bigint", nullable: true),
                    FoodId = table.Column<long>(type: "bigint", nullable: true),
                    ReceiverId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Requisition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Requisition_Tbl_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Tbl_Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Requisition_Tbl_User_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Requisition_Tbl_User_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Food_UserId",
                table: "Tbl_Food",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Requisition_DonorId",
                table: "Tbl_Requisition",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Requisition_FoodId",
                table: "Tbl_Requisition",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Requisition_ReceiverId",
                table: "Tbl_Requisition",
                column: "ReceiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Requisition");

            migrationBuilder.DropTable(
                name: "Tbl_Food");
        }
    }
}

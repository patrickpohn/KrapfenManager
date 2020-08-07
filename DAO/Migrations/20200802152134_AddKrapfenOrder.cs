using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class AddKrapfenOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Krapfen_Order_OrderId",
                table: "Krapfen");

            migrationBuilder.DropIndex(
                name: "IX_Krapfen_OrderId",
                table: "Krapfen");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Krapfen");

            migrationBuilder.AddColumn<Guid>(
                name: "KrapfenOrderId",
                table: "Krapfen",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KrapfenOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrapfenOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KrapfenOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Krapfen_KrapfenOrderId",
                table: "Krapfen",
                column: "KrapfenOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_KrapfenOrder_OrderId",
                table: "KrapfenOrder",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Krapfen_KrapfenOrder_KrapfenOrderId",
                table: "Krapfen",
                column: "KrapfenOrderId",
                principalTable: "KrapfenOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Krapfen_KrapfenOrder_KrapfenOrderId",
                table: "Krapfen");

            migrationBuilder.DropTable(
                name: "KrapfenOrder");

            migrationBuilder.DropIndex(
                name: "IX_Krapfen_KrapfenOrderId",
                table: "Krapfen");

            migrationBuilder.DropColumn(
                name: "KrapfenOrderId",
                table: "Krapfen");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Krapfen",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Krapfen_OrderId",
                table: "Krapfen",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Krapfen_Order_OrderId",
                table: "Krapfen",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class Adjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KrapfenOrder_Order_OrderId",
                table: "KrapfenOrder");

            migrationBuilder.DropIndex(
                name: "IX_KrapfenOrder_OrderId",
                table: "KrapfenOrder");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "KrapfenOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "KrapfenOrderId",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_KrapfenOrderId",
                table: "Order",
                column: "KrapfenOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_KrapfenOrder_KrapfenOrderId",
                table: "Order",
                column: "KrapfenOrderId",
                principalTable: "KrapfenOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_KrapfenOrder_KrapfenOrderId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_KrapfenOrderId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "KrapfenOrderId",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "KrapfenOrder",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KrapfenOrder_OrderId",
                table: "KrapfenOrder",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_KrapfenOrder_Order_OrderId",
                table: "KrapfenOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

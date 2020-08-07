using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class FixKrapfenORder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Krapfen_KrapfenOrder_KrapfenOrderId",
                table: "Krapfen");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_KrapfenOrder_KrapfenOrderId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_KrapfenOrderId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Krapfen_KrapfenOrderId",
                table: "Krapfen");

            migrationBuilder.DropColumn(
                name: "KrapfenOrderId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "KrapfenOrderId",
                table: "Krapfen");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Event");

            migrationBuilder.AddColumn<Guid>(
                name: "KrapfenId",
                table: "KrapfenOrder",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "KrapfenOrder",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KrapfenOrder_Order_OrderId",
                table: "KrapfenOrder");

            migrationBuilder.DropIndex(
                name: "IX_KrapfenOrder_OrderId",
                table: "KrapfenOrder");

            migrationBuilder.DropColumn(
                name: "KrapfenId",
                table: "KrapfenOrder");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "KrapfenOrder");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Event");

            migrationBuilder.AddColumn<Guid>(
                name: "KrapfenOrderId",
                table: "Order",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KrapfenOrderId",
                table: "Krapfen",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Type",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Order_KrapfenOrderId",
                table: "Order",
                column: "KrapfenOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Krapfen_KrapfenOrderId",
                table: "Krapfen",
                column: "KrapfenOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Krapfen_KrapfenOrder_KrapfenOrderId",
                table: "Krapfen",
                column: "KrapfenOrderId",
                principalTable: "KrapfenOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_KrapfenOrder_KrapfenOrderId",
                table: "Order",
                column: "KrapfenOrderId",
                principalTable: "KrapfenOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class AddSomeMoreRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventKrapfen_Event_EventId",
                table: "EventKrapfen");

            migrationBuilder.DropForeignKey(
                name: "FK_EventKrapfen_Krapfen_KrapfenId",
                table: "EventKrapfen");

            migrationBuilder.DropForeignKey(
                name: "FK_KrapfenOrder_Order_OrderId",
                table: "KrapfenOrder");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "KrapfenOrder",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "KrapfenId",
                table: "EventKrapfen",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "EventKrapfen",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventKrapfen_Event_EventId",
                table: "EventKrapfen",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventKrapfen_Krapfen_KrapfenId",
                table: "EventKrapfen",
                column: "KrapfenId",
                principalTable: "Krapfen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_EventKrapfen_Event_EventId",
                table: "EventKrapfen");

            migrationBuilder.DropForeignKey(
                name: "FK_EventKrapfen_Krapfen_KrapfenId",
                table: "EventKrapfen");

            migrationBuilder.DropForeignKey(
                name: "FK_KrapfenOrder_Order_OrderId",
                table: "KrapfenOrder");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "KrapfenOrder",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "KrapfenId",
                table: "EventKrapfen",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "EventKrapfen",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_EventKrapfen_Event_EventId",
                table: "EventKrapfen",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventKrapfen_Krapfen_KrapfenId",
                table: "EventKrapfen",
                column: "KrapfenId",
                principalTable: "Krapfen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

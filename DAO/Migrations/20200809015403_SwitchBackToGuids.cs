﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class SwitchBackToGuids : Migration
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
                name: "FK_KrapfenOrder_Krapfen_KrapfenId",
                table: "KrapfenOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_KrapfenOrder_Order_OrderId",
                table: "KrapfenOrder");

            migrationBuilder.DropIndex(
                name: "IX_KrapfenOrder_KrapfenId",
                table: "KrapfenOrder");

            migrationBuilder.DropIndex(
                name: "IX_EventKrapfen_KrapfenId",
                table: "EventKrapfen");

            migrationBuilder.DropColumn(
                name: "KrapfenId",
                table: "KrapfenOrder");

            migrationBuilder.DropColumn(
                name: "KrapfenId",
                table: "EventKrapfen");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "KrapfenOrder",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddColumn<Guid>(
                name: "Krapfen",
                table: "KrapfenOrder",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Order",
                table: "KrapfenOrder",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "EventKrapfen",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddColumn<Guid>(
                name: "Event",
                table: "EventKrapfen",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Krapfen",
                table: "EventKrapfen",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_EventKrapfen_Event_EventId",
                table: "EventKrapfen",
                column: "EventId",
                principalTable: "Event",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventKrapfen_Event_EventId",
                table: "EventKrapfen");

            migrationBuilder.DropForeignKey(
                name: "FK_KrapfenOrder_Order_OrderId",
                table: "KrapfenOrder");

            migrationBuilder.DropColumn(
                name: "Krapfen",
                table: "KrapfenOrder");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "KrapfenOrder");

            migrationBuilder.DropColumn(
                name: "Event",
                table: "EventKrapfen");

            migrationBuilder.DropColumn(
                name: "Krapfen",
                table: "EventKrapfen");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "KrapfenOrder",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KrapfenId",
                table: "KrapfenOrder",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "EventKrapfen",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KrapfenId",
                table: "EventKrapfen",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_KrapfenOrder_KrapfenId",
                table: "KrapfenOrder",
                column: "KrapfenId");

            migrationBuilder.CreateIndex(
                name: "IX_EventKrapfen_KrapfenId",
                table: "EventKrapfen",
                column: "KrapfenId");

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
                name: "FK_KrapfenOrder_Krapfen_KrapfenId",
                table: "KrapfenOrder",
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
    }
}

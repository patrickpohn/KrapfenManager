using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class ShiftKrapfenId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Krapfen_KrapfenOrder_KrapfenOrderId",
                table: "Krapfen");

            migrationBuilder.DropIndex(
                name: "IX_Krapfen_KrapfenOrderId",
                table: "Krapfen");

            migrationBuilder.DropColumn(
                name: "KrapfenOrderId",
                table: "Krapfen");

            migrationBuilder.AddColumn<Guid>(
                name: "KrapfenId",
                table: "KrapfenOrder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KrapfenOrder_KrapfenId",
                table: "KrapfenOrder",
                column: "KrapfenId");

            migrationBuilder.AddForeignKey(
                name: "FK_KrapfenOrder_Krapfen_KrapfenId",
                table: "KrapfenOrder",
                column: "KrapfenId",
                principalTable: "Krapfen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KrapfenOrder_Krapfen_KrapfenId",
                table: "KrapfenOrder");

            migrationBuilder.DropIndex(
                name: "IX_KrapfenOrder_KrapfenId",
                table: "KrapfenOrder");

            migrationBuilder.DropColumn(
                name: "KrapfenId",
                table: "KrapfenOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "KrapfenOrderId",
                table: "Krapfen",
                type: "char(36)",
                nullable: true);

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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "DbSetKrapfen",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DbSetOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderName = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetOrder", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbSetKrapfen_OrderId",
                table: "DbSetKrapfen",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSetKrapfen_DbSetOrder_OrderId",
                table: "DbSetKrapfen",
                column: "OrderId",
                principalTable: "DbSetOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbSetKrapfen_DbSetOrder_OrderId",
                table: "DbSetKrapfen");

            migrationBuilder.DropTable(
                name: "DbSetOrder");

            migrationBuilder.DropIndex(
                name: "IX_DbSetKrapfen_OrderId",
                table: "DbSetKrapfen");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "DbSetKrapfen");
        }
    }
}

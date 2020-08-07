using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class EventKrapfen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Krapfen_Event_EventId",
                table: "Krapfen");

            migrationBuilder.DropIndex(
                name: "IX_Krapfen_EventId",
                table: "Krapfen");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Krapfen");

            migrationBuilder.CreateTable(
                name: "EventKrapfen",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false),
                    KrapfenId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventKrapfen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventKrapfen_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventKrapfen_EventId",
                table: "EventKrapfen",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventKrapfen");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Krapfen",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Krapfen_EventId",
                table: "Krapfen",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Krapfen_Event_EventId",
                table: "Krapfen",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

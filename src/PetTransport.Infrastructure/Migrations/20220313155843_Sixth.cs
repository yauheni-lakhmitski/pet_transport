using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TransportationId",
                table: "Routes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Transportation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TransportationId",
                table: "Routes",
                column: "TransportationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Transportation_TransportationId",
                table: "Routes",
                column: "TransportationId",
                principalTable: "Transportation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Transportation_TransportationId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "Transportation");

            migrationBuilder.DropIndex(
                name: "IX_Routes_TransportationId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "TransportationId",
                table: "Routes");
        }
    }
}

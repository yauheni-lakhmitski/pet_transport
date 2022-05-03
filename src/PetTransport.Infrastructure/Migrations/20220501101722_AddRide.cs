using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class AddRide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "ApplicationItems");

            migrationBuilder.AddColumn<Guid>(
                name: "RideId",
                table: "Applications",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ride",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    From = table.Column<string>(type: "TEXT", nullable: false),
                    To = table.Column<string>(type: "TEXT", nullable: false),
                    CarId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ride", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ride_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ride_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_RideId",
                table: "Applications",
                column: "RideId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_CarId",
                table: "Ride",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_UserId",
                table: "Ride",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Ride_RideId",
                table: "Applications",
                column: "RideId",
                principalTable: "Ride",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Ride_RideId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "Ride");

            migrationBuilder.DropIndex(
                name: "IX_Applications_RideId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "RideId",
                table: "Applications");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "ApplicationItems",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

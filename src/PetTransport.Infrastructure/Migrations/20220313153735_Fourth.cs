using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserTrip");

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "Cars",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarId",
                table: "Cars",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cars_CarId",
                table: "Cars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cars_CarId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserTrip",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}

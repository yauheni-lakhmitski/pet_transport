using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class AddCreatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PickUpDate",
                table: "Applications");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "Applications",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "Applications");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PickUpDate",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

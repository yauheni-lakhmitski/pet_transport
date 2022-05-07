using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class AddAnimalType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Rides_RideId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "AnimalType",
                table: "ApplicationItems",
                newName: "AnimalTypeId");

            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AnimalTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationItems_AnimalTypeId",
                table: "ApplicationItems",
                column: "AnimalTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationItems_AnimalTypes_AnimalTypeId",
                table: "ApplicationItems",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Rides_RideId",
                table: "Applications",
                column: "RideId",
                principalTable: "Rides",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationItems_AnimalTypes_AnimalTypeId",
                table: "ApplicationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Rides_RideId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationItems_AnimalTypeId",
                table: "ApplicationItems");

            migrationBuilder.RenameColumn(
                name: "AnimalTypeId",
                table: "ApplicationItems",
                newName: "AnimalType");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Rides_RideId",
                table: "Applications",
                column: "RideId",
                principalTable: "Rides",
                principalColumn: "Id");
        }
    }
}

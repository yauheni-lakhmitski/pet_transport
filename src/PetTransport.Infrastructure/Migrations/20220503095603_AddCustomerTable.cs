using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class AddCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationItems_Applications_ApplicationId",
                table: "ApplicationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Rides_RideId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_RideId",
                table: "Application",
                newName: "IX_Application_RideId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Application",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    OrganizationNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ContantPerson = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_CustomerId",
                table: "Application",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Customer_CustomerId",
                table: "Application",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Rides_RideId",
                table: "Application",
                column: "RideId",
                principalTable: "Rides",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationItems_Application_ApplicationId",
                table: "ApplicationItems",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Customer_CustomerId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Rides_RideId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationItems_Application_ApplicationId",
                table: "ApplicationItems");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_CustomerId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Application");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_Application_RideId",
                table: "Applications",
                newName: "IX_Applications_RideId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationItems_Applications_ApplicationId",
                table: "ApplicationItems",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Rides_RideId",
                table: "Applications",
                column: "RideId",
                principalTable: "Rides",
                principalColumn: "Id");
        }
    }
}

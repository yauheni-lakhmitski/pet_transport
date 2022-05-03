using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class AddRideTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Ride_RideId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_AspNetUsers_UserId",
                table: "Ride");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Cars_CarId",
                table: "Ride");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ride",
                table: "Ride");

            migrationBuilder.RenameTable(
                name: "Ride",
                newName: "Rides");

            migrationBuilder.RenameIndex(
                name: "IX_Ride_UserId",
                table: "Rides",
                newName: "IX_Rides_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ride_CarId",
                table: "Rides",
                newName: "IX_Rides_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rides",
                table: "Rides",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Rides_RideId",
                table: "Applications",
                column: "RideId",
                principalTable: "Rides",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_AspNetUsers_UserId",
                table: "Rides",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Cars_CarId",
                table: "Rides",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Rides_RideId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_AspNetUsers_UserId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Cars_CarId",
                table: "Rides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rides",
                table: "Rides");

            migrationBuilder.RenameTable(
                name: "Rides",
                newName: "Ride");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_UserId",
                table: "Ride",
                newName: "IX_Ride_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_CarId",
                table: "Ride",
                newName: "IX_Ride_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ride",
                table: "Ride",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Ride_RideId",
                table: "Applications",
                column: "RideId",
                principalTable: "Ride",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_AspNetUsers_UserId",
                table: "Ride",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Cars_CarId",
                table: "Ride",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class Ninth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetType",
                table: "Orders",
                newName: "SenderFullName");

            migrationBuilder.RenameColumn(
                name: "PetName",
                table: "Orders",
                newName: "PetSex");

            migrationBuilder.RenameColumn(
                name: "LastNameSender",
                table: "Orders",
                newName: "PetDateOfBirth");

            migrationBuilder.RenameColumn(
                name: "LastNameReceiver",
                table: "Orders",
                newName: "PetColor");

            migrationBuilder.RenameColumn(
                name: "FirstNameSender",
                table: "Orders",
                newName: "PetBreed");

            migrationBuilder.RenameColumn(
                name: "FirstNameReceiver",
                table: "Orders",
                newName: "FullNameReceiver");

            migrationBuilder.RenameColumn(
                name: "CitySender",
                table: "Orders",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "CityReceiver",
                table: "Orders",
                newName: "AddressReceiver");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderFullName",
                table: "Orders",
                newName: "PetType");

            migrationBuilder.RenameColumn(
                name: "PetSex",
                table: "Orders",
                newName: "PetName");

            migrationBuilder.RenameColumn(
                name: "PetDateOfBirth",
                table: "Orders",
                newName: "LastNameSender");

            migrationBuilder.RenameColumn(
                name: "PetColor",
                table: "Orders",
                newName: "LastNameReceiver");

            migrationBuilder.RenameColumn(
                name: "PetBreed",
                table: "Orders",
                newName: "FirstNameSender");

            migrationBuilder.RenameColumn(
                name: "FullNameReceiver",
                table: "Orders",
                newName: "FirstNameReceiver");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Orders",
                newName: "CitySender");

            migrationBuilder.RenameColumn(
                name: "AddressReceiver",
                table: "Orders",
                newName: "CityReceiver");
        }
    }
}

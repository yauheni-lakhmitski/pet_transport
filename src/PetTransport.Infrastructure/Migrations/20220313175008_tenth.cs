using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class tenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumberSender",
                table: "Orders",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberReceiver",
                table: "Orders",
                newName: "TransferPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PetSex",
                table: "Orders",
                newName: "ShelterFrom");

            migrationBuilder.RenameColumn(
                name: "PetDateOfBirth",
                table: "Orders",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "PetColor",
                table: "Orders",
                newName: "SenderWhatsApp");

            migrationBuilder.RenameColumn(
                name: "PetBreed",
                table: "Orders",
                newName: "SenderStreet");

            migrationBuilder.RenameColumn(
                name: "FullNameReceiver",
                table: "Orders",
                newName: "SenderRegion");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Orders",
                newName: "SenderPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "AddressReceiver",
                table: "Orders",
                newName: "SenderEmail");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Airport",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChipNumber",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryOfDestination",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Courier",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfChip",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "RailwayStation",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RecipientEmail",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientFullName",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientPhoneNumber",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientStreet",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientWhatsApp",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientZip",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderCity",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Airport",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ChipNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CountryOfDestination",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Courier",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateOfChip",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RailwayStation",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RecipientEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RecipientFullName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RecipientPhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RecipientStreet",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RecipientWhatsApp",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RecipientZip",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderCity",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Orders",
                newName: "PhoneNumberSender");

            migrationBuilder.RenameColumn(
                name: "TransferPhoneNumber",
                table: "Orders",
                newName: "PhoneNumberReceiver");

            migrationBuilder.RenameColumn(
                name: "ShelterFrom",
                table: "Orders",
                newName: "PetSex");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Orders",
                newName: "PetDateOfBirth");

            migrationBuilder.RenameColumn(
                name: "SenderWhatsApp",
                table: "Orders",
                newName: "PetColor");

            migrationBuilder.RenameColumn(
                name: "SenderStreet",
                table: "Orders",
                newName: "PetBreed");

            migrationBuilder.RenameColumn(
                name: "SenderRegion",
                table: "Orders",
                newName: "FullNameReceiver");

            migrationBuilder.RenameColumn(
                name: "SenderPhoneNumber",
                table: "Orders",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "SenderEmail",
                table: "Orders",
                newName: "AddressReceiver");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstNameSender = table.Column<string>(type: "TEXT", nullable: false),
                    LastNameSender = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumberSender = table.Column<string>(type: "TEXT", nullable: false),
                    CitySender = table.Column<string>(type: "TEXT", nullable: false),
                    FirstNameReceiver = table.Column<string>(type: "TEXT", nullable: false),
                    LastNameReceiver = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumberReceiver = table.Column<string>(type: "TEXT", nullable: false),
                    CityReceiver = table.Column<string>(type: "TEXT", nullable: false),
                    PetName = table.Column<string>(type: "TEXT", nullable: false),
                    PetType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

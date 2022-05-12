using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class AddPatronymic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DriverLicence",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatronymicName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverLicence",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PatronymicName",
                table: "AspNetUsers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class AddLoadCapacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LoadCapacity",
                table: "Cars",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoadCapacity",
                table: "Cars");
        }
    }
}

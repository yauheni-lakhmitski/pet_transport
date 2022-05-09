using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class AddLoadCapacity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LoadCapacity",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LoadCapacity",
                table: "Cars",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}

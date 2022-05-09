using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class AddManagerToApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "ApplicationItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ManagerId",
                table: "Applications",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_ManagerId",
                table: "Applications",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_ManagerId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ManagerId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "ApplicationItems");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class Eighth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Transportation_TransportationId",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transportation",
                table: "Transportation");

            migrationBuilder.RenameTable(
                name: "Transportation",
                newName: "Transportations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transportations",
                table: "Transportations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Transportations_TransportationId",
                table: "Routes",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Transportations_TransportationId",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transportations",
                table: "Transportations");

            migrationBuilder.RenameTable(
                name: "Transportations",
                newName: "Transportation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transportation",
                table: "Transportation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Transportation_TransportationId",
                table: "Routes",
                column: "TransportationId",
                principalTable: "Transportation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

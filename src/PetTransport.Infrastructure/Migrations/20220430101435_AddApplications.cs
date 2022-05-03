using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTransport.Infrastructure.Migrations
{
    public partial class AddApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InviteCodes_Trips_TripId",
                table: "InviteCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Trips_TripId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_AspNetUsers_DriverId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Cars_CarId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Transportations_TransportationId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskLists_TaskListId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLists_Trips_TripId",
                table: "TaskLists");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLists",
                table: "TaskLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routes",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InviteCodes",
                table: "InviteCodes");

            migrationBuilder.RenameTable(
                name: "TaskLists",
                newName: "TaskList");

            migrationBuilder.RenameTable(
                name: "Routes",
                newName: "Route");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "InviteCodes",
                newName: "InviteCode");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLists_TripId",
                table: "TaskList",
                newName: "IX_TaskList_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_TransportationId",
                table: "Route",
                newName: "IX_Route_TransportationId");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_DriverId",
                table: "Route",
                newName: "IX_Route_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_CarId",
                table: "Route",
                newName: "IX_Route_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Message",
                newName: "IX_Message_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_TripId",
                table: "Message",
                newName: "IX_Message_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_InviteCodes_TripId",
                table: "InviteCode",
                newName: "IX_InviteCode_TripId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskList",
                table: "TaskList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Route",
                table: "Route",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InviteCode",
                table: "InviteCode",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    SourcePoint = table.Column<string>(type: "TEXT", nullable: false),
                    DestinationPoint = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChipNumber = table.Column<string>(type: "TEXT", nullable: false),
                    AnimalType = table.Column<string>(type: "TEXT", nullable: false),
                    AnimalName = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Discount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationItems_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationItems_ApplicationId",
                table: "ApplicationItems",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InviteCode_Trips_TripId",
                table: "InviteCode",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Trips_TripId",
                table: "Message",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_AspNetUsers_DriverId",
                table: "Route",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Cars_CarId",
                table: "Route",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Transportations_TransportationId",
                table: "Route",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskList_TaskListId",
                table: "Task",
                column: "TaskListId",
                principalTable: "TaskList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_Trips_TripId",
                table: "TaskList",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InviteCode_Trips_TripId",
                table: "InviteCode");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_UserId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Trips_TripId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_AspNetUsers_DriverId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_Cars_CarId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_Transportations_TransportationId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskList_TaskListId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_Trips_TripId",
                table: "TaskList");

            migrationBuilder.DropTable(
                name: "ApplicationItems");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskList",
                table: "TaskList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Route",
                table: "Route");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InviteCode",
                table: "InviteCode");

            migrationBuilder.RenameTable(
                name: "TaskList",
                newName: "TaskLists");

            migrationBuilder.RenameTable(
                name: "Route",
                newName: "Routes");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "InviteCode",
                newName: "InviteCodes");

            migrationBuilder.RenameIndex(
                name: "IX_TaskList_TripId",
                table: "TaskLists",
                newName: "IX_TaskLists_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_Route_TransportationId",
                table: "Routes",
                newName: "IX_Routes_TransportationId");

            migrationBuilder.RenameIndex(
                name: "IX_Route_DriverId",
                table: "Routes",
                newName: "IX_Routes_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Route_CarId",
                table: "Routes",
                newName: "IX_Routes_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_UserId",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_TripId",
                table: "Messages",
                newName: "IX_Messages_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_InviteCode_TripId",
                table: "InviteCodes",
                newName: "IX_InviteCodes_TripId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLists",
                table: "TaskLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routes",
                table: "Routes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InviteCodes",
                table: "InviteCodes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Airport = table.Column<bool>(type: "INTEGER", nullable: false),
                    Breed = table.Column<string>(type: "TEXT", nullable: false),
                    ChipNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    CountryOfDestination = table.Column<string>(type: "TEXT", nullable: false),
                    Courier = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfChip = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    RailwayStation = table.Column<bool>(type: "INTEGER", nullable: false),
                    RecipientEmail = table.Column<string>(type: "TEXT", nullable: false),
                    RecipientFullName = table.Column<string>(type: "TEXT", nullable: false),
                    RecipientPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RecipientStreet = table.Column<string>(type: "TEXT", nullable: false),
                    RecipientWhatsApp = table.Column<string>(type: "TEXT", nullable: false),
                    RecipientZip = table.Column<string>(type: "TEXT", nullable: false),
                    SenderCity = table.Column<string>(type: "TEXT", nullable: false),
                    SenderEmail = table.Column<string>(type: "TEXT", nullable: false),
                    SenderFullName = table.Column<string>(type: "TEXT", nullable: false),
                    SenderPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    SenderRegion = table.Column<string>(type: "TEXT", nullable: false),
                    SenderStreet = table.Column<string>(type: "TEXT", nullable: false),
                    SenderWhatsApp = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    ShelterFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TransferPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Zip = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_InviteCodes_Trips_TripId",
                table: "InviteCodes",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Trips_TripId",
                table: "Messages",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_AspNetUsers_DriverId",
                table: "Routes",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Cars_CarId",
                table: "Routes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Transportations_TransportationId",
                table: "Routes",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskLists_TaskListId",
                table: "Task",
                column: "TaskListId",
                principalTable: "TaskLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLists_Trips_TripId",
                table: "TaskLists",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

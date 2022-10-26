using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomsBookingAPI.DataAccess.Migrations
{
    public partial class CustomerDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: true),
                    NIC = table.Column<string>(type: "varchar(11)", nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", nullable: true),
                    ContactNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    CheckIN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hotelDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    ContactNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roomDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "varchar(200)", nullable: true),
                    PeopleCount = table.Column<string>(type: "varchar(20)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roomDetails_hotelDetails_HotelID",
                        column: x => x.HotelID,
                        principalTable: "hotelDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "room_X_Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_X_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_room_X_Customers_customerDetails_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "customerDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_room_X_Customers_roomDetails_RoomID",
                        column: x => x.RoomID,
                        principalTable: "roomDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_room_X_Customers_CustomerID",
                table: "room_X_Customers",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_room_X_Customers_RoomID",
                table: "room_X_Customers",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_roomDetails_HotelID",
                table: "roomDetails",
                column: "HotelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "room_X_Customers");

            migrationBuilder.DropTable(
                name: "customerDetails");

            migrationBuilder.DropTable(
                name: "roomDetails");

            migrationBuilder.DropTable(
                name: "hotelDetails");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineAuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuctionDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    StartingPrice = table.Column<double>(type: "float", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionDbs_UserDbs_SellerId",
                        column: x => x.SellerId,
                        principalTable: "UserDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidAmount = table.Column<double>(type: "float", nullable: false),
                    BidderId = table.Column<int>(type: "int", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidDbs_AuctionDbs_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BidDbs_UserDbs_BidderId",
                        column: x => x.BidderId,
                        principalTable: "UserDbs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "UserDbs",
                column: "Id",
                values: new object[]
                {
                    -2,
                    -1
                });

            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "Description", "EndTime", "Name", "SellerId", "StartingPrice" },
                values: new object[,]
                {
                    { -2, "Description for Auction 2", new DateTime(2023, 10, 15, 21, 39, 49, 820, DateTimeKind.Local).AddTicks(8741), "Auction 2", -2, 50.0 },
                    { -1, "Description for Auction 1", new DateTime(2023, 10, 14, 21, 39, 49, 820, DateTimeKind.Local).AddTicks(8654), "Auction 1", -1, 100.0 }
                });

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "AuctionId", "BidAmount", "BidderId" },
                values: new object[,]
                {
                    { -2, -2, 60.0, -1 },
                    { -1, -1, 120.0, -2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDbs_SellerId",
                table: "AuctionDbs",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_BidDbs_AuctionId",
                table: "BidDbs",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_BidDbs_BidderId",
                table: "BidDbs",
                column: "BidderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidDbs");

            migrationBuilder.DropTable(
                name: "AuctionDbs");

            migrationBuilder.DropTable(
                name: "UserDbs");
        }
    }
}

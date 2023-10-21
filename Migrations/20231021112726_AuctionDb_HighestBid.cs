using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class AuctionDb_HighestBid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestAmount",
                table: "AuctionDbs");

            migrationBuilder.AddColumn<int>(
                name: "HighestBidId",
                table: "AuctionDbs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "EndTime", "HighestBidId" },
                values: new object[] { new DateTime(2023, 10, 23, 13, 27, 26, 432, DateTimeKind.Local).AddTicks(7071), null });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "EndTime", "HighestBidId" },
                values: new object[] { new DateTime(2023, 10, 22, 13, 27, 26, 432, DateTimeKind.Local).AddTicks(6998), null });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDbs_HighestBidId",
                table: "AuctionDbs",
                column: "HighestBidId",
                unique: true,
                filter: "[HighestBidId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDbs_BidDbs_HighestBidId",
                table: "AuctionDbs",
                column: "HighestBidId",
                principalTable: "BidDbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDbs_BidDbs_HighestBidId",
                table: "AuctionDbs");

            migrationBuilder.DropIndex(
                name: "IX_AuctionDbs_HighestBidId",
                table: "AuctionDbs");

            migrationBuilder.DropColumn(
                name: "HighestBidId",
                table: "AuctionDbs");

            migrationBuilder.AddColumn<double>(
                name: "HighestAmount",
                table: "AuctionDbs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "EndTime", "HighestAmount" },
                values: new object[] { new DateTime(2023, 10, 20, 15, 46, 17, 159, DateTimeKind.Local).AddTicks(191), 0.0 });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "EndTime", "HighestAmount" },
                values: new object[] { new DateTime(2023, 10, 19, 15, 46, 17, 159, DateTimeKind.Local).AddTicks(148), 0.0 });
        }
    }
}

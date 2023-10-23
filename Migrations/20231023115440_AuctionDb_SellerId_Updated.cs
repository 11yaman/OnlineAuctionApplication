using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class AuctionDb_SellerId_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDbs_BidDbs_HighestBidId",
                table: "AuctionDbs");

            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDbs_UserDbs_SellerId",
                table: "AuctionDbs");

            migrationBuilder.DropIndex(
                name: "IX_AuctionDbs_HighestBidId",
                table: "AuctionDbs");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2023, 10, 25, 13, 54, 40, 789, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2023, 10, 24, 13, 54, 40, 789, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDbs_HighestBidId",
                table: "AuctionDbs",
                column: "HighestBidId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDbs_BidDbs_HighestBidId",
                table: "AuctionDbs",
                column: "HighestBidId",
                principalTable: "BidDbs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDbs_UserDbs_SellerId",
                table: "AuctionDbs",
                column: "SellerId",
                principalTable: "UserDbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDbs_BidDbs_HighestBidId",
                table: "AuctionDbs");

            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDbs_UserDbs_SellerId",
                table: "AuctionDbs");

            migrationBuilder.DropIndex(
                name: "IX_AuctionDbs_HighestBidId",
                table: "AuctionDbs");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2023, 10, 25, 13, 25, 48, 800, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2023, 10, 24, 13, 25, 48, 800, DateTimeKind.Local).AddTicks(8305));

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

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDbs_UserDbs_SellerId",
                table: "AuctionDbs",
                column: "SellerId",
                principalTable: "UserDbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

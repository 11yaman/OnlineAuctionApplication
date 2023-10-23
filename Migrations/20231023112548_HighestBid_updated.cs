using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class HighestBid_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BidDbs_UserDbs_BidderId",
                table: "BidDbs");

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

            migrationBuilder.UpdateData(
                table: "UserDbs",
                keyColumn: "Id",
                keyValue: "-1",
                column: "UserRole",
                value: "User");

            migrationBuilder.UpdateData(
                table: "UserDbs",
                keyColumn: "Id",
                keyValue: "-2",
                column: "UserRole",
                value: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_BidDbs_UserDbs_BidderId",
                table: "BidDbs",
                column: "BidderId",
                principalTable: "UserDbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BidDbs_UserDbs_BidderId",
                table: "BidDbs");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2023, 10, 24, 21, 21, 10, 739, DateTimeKind.Local).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2023, 10, 23, 21, 21, 10, 739, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "UserDbs",
                keyColumn: "Id",
                keyValue: "-1",
                column: "UserRole",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserDbs",
                keyColumn: "Id",
                keyValue: "-2",
                column: "UserRole",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_BidDbs_UserDbs_BidderId",
                table: "BidDbs",
                column: "BidderId",
                principalTable: "UserDbs",
                principalColumn: "Id");
        }
    }
}

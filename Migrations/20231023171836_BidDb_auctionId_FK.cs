using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class BidDb_auctionId_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2023, 10, 25, 19, 18, 36, 170, DateTimeKind.Local).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2023, 10, 24, 19, 18, 36, 170, DateTimeKind.Local).AddTicks(6167));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2023, 10, 25, 14, 24, 19, 7, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2023, 10, 24, 14, 24, 19, 7, DateTimeKind.Local).AddTicks(1016));
        }
    }
}

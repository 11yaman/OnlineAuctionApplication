using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class UserDbs_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2023, 10, 17, 0, 13, 25, 389, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2023, 10, 16, 0, 13, 25, 389, DateTimeKind.Local).AddTicks(9301));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2023, 10, 16, 23, 56, 33, 668, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2023, 10, 15, 23, 56, 33, 668, DateTimeKind.Local).AddTicks(1046));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class BidDb_BidderId_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BidderId",
                table: "BidDbs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2023, 10, 25, 14, 15, 54, 958, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2023, 10, 24, 14, 15, 54, 958, DateTimeKind.Local).AddTicks(2872));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BidderId",
                table: "BidDbs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
        }
    }
}

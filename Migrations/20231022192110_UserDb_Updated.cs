using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class UserDb_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "UserDbs",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "UserDbs");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2023, 10, 23, 13, 27, 26, 432, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2023, 10, 22, 13, 27, 26, 432, DateTimeKind.Local).AddTicks(6998));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class AuctionDb_HighestAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestAmount",
                table: "AuctionDbs");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2023, 10, 20, 12, 27, 42, 124, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2023, 10, 19, 12, 27, 42, 124, DateTimeKind.Local).AddTicks(929));
        }
    }
}

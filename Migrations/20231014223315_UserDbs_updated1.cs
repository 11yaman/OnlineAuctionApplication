using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class UserDbs_updated1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserDbs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2023, 10, 17, 0, 33, 15, 861, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2023, 10, 16, 0, 33, 15, 861, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.CreateIndex(
                name: "IX_UserDbs_Username",
                table: "UserDbs",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDbs_Username",
                table: "UserDbs");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserDbs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}

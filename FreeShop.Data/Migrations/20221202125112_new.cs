using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeShop.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 15, 51, 12, 554, DateTimeKind.Local).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 15, 51, 12, 554, DateTimeKind.Local).AddTicks(830));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 1, 15, 30, 28, 238, DateTimeKind.Local).AddTicks(1735));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 1, 15, 30, 28, 238, DateTimeKind.Local).AddTicks(1753));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeShop.Data.Migrations
{
    public partial class username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 5, 19, 8, 43, 769, DateTimeKind.Local).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 5, 19, 8, 43, 769, DateTimeKind.Local).AddTicks(6147));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 3, 19, 3, 45, 189, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 3, 19, 3, 45, 189, DateTimeKind.Local).AddTicks(4693));
        }
    }
}

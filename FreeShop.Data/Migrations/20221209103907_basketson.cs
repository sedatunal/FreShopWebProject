using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeShop.Data.Migrations
{
    public partial class basketson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 13, 39, 6, 493, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 13, 39, 6, 493, DateTimeKind.Local).AddTicks(9495));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 13, 37, 4, 537, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 13, 37, 4, 537, DateTimeKind.Local).AddTicks(1172));
        }
    }
}

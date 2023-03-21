using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeShop.Data.Migrations
{
    public partial class commentusername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 15, 33, 55, 932, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 16, 15, 33, 55, 932, DateTimeKind.Local).AddTicks(1995));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 12, 16, 23, 14, 183, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 12, 16, 23, 14, 183, DateTimeKind.Local).AddTicks(2777));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeShop.Data.Migrations
{
    public partial class comment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 7, 1, 16, 11, 798, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 7, 1, 16, 11, 798, DateTimeKind.Local).AddTicks(495));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 7, 1, 3, 39, 842, DateTimeKind.Local).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 7, 1, 3, 39, 842, DateTimeKind.Local).AddTicks(3957));
        }
    }
}

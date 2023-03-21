using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeShop.Data.Migrations
{
    public partial class basketsonnnnnnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingBasketEntityId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingBaskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBaskets", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 13, 45, 36, 358, DateTimeKind.Local).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 13, 45, 36, 358, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingBasketEntityId",
                table: "Products",
                column: "ShoppingBasketEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingBaskets_ShoppingBasketEntityId",
                table: "Products",
                column: "ShoppingBasketEntityId",
                principalTable: "ShoppingBaskets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingBaskets_ShoppingBasketEntityId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingBaskets");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingBasketEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingBasketEntityId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 13, 39, 52, 9, DateTimeKind.Local).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 13, 39, 52, 9, DateTimeKind.Local).AddTicks(6498));
        }
    }
}

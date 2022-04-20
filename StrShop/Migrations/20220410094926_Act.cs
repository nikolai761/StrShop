using Microsoft.EntityFrameworkCore.Migrations;

namespace StrShop.Migrations
{
    public partial class Act : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                table: "ShopCartItems");

            migrationBuilder.AddColumn<bool>(
                name: "isAction",
                table: "Item",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAction",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "ShopCartItems",
                nullable: false,
                defaultValue: 0);
        }
    }
}

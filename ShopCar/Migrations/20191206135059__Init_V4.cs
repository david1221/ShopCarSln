using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCar.Migrations
{
    public partial class _Init_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "ShopCartItems",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "ShopCartItems",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace restaurant_booking_Infrastructure.Migrations
{
    public partial class addedQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityOrdered",
                table: "CartProduct",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityOrdered",
                table: "CartProduct");
        }
    }
}

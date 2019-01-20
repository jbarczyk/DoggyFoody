using Microsoft.EntityFrameworkCore.Migrations;

namespace DoggyFoody.Database.Migrations
{
    public partial class AddedFoodTypeToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodType",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodType",
                table: "Products");
        }
    }
}

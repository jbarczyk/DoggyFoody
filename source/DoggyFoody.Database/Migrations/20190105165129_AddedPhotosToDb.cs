using Microsoft.EntityFrameworkCore.Migrations;

namespace DoggyFoody.Database.Migrations
{
    public partial class AddedPhotosToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageAddress",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageAddress",
                table: "Advertisements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAddress",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageAddress",
                table: "Advertisements");
        }
    }
}

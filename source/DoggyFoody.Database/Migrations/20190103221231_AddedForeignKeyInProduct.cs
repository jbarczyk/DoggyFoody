using Microsoft.EntityFrameworkCore.Migrations;

namespace DoggyFoody.Database.Migrations
{
    public partial class AddedForeignKeyInProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ManufacturerId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ManufacturerId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(long));
        }
    }
}

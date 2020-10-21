using Microsoft.EntityFrameworkCore.Migrations;

namespace Cake_Shop.Migrations
{
    public partial class cartmodelchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Cart",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Cart");
        }
    }
}

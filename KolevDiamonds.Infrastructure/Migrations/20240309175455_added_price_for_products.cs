using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class added_price_for_products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Rings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Price of the product");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Necklaces",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Price of the product");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MetalBars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Price of the product");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "InvestmentDiamonds",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Price of the product");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "InvestmentCoins",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Price of the product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Necklaces");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MetalBars");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "InvestmentDiamonds");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "InvestmentCoins");
        }
    }
}

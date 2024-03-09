using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class added_images_for_products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RingImagePath",
                table: "Rings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Server file system image path");

            migrationBuilder.AddColumn<string>(
                name: "NecklaceImagePath",
                table: "Necklaces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Server file system image path");

            migrationBuilder.AddColumn<string>(
                name: "MetalBarImagePath",
                table: "MetalBars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Server file system image path");

            migrationBuilder.AddColumn<string>(
                name: "DiamondImagePath",
                table: "InvestmentDiamonds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Server file system image path");

            migrationBuilder.AddColumn<string>(
                name: "CoinImagePath",
                table: "InvestmentCoins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Server file system image path");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RingImagePath",
                table: "Rings");

            migrationBuilder.DropColumn(
                name: "NecklaceImagePath",
                table: "Necklaces");

            migrationBuilder.DropColumn(
                name: "MetalBarImagePath",
                table: "MetalBars");

            migrationBuilder.DropColumn(
                name: "DiamondImagePath",
                table: "InvestmentDiamonds");

            migrationBuilder.DropColumn(
                name: "CoinImagePath",
                table: "InvestmentCoins");
        }
    }
}

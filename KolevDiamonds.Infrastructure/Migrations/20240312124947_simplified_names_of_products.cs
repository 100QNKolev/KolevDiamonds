using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class simplified_names_of_products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RingName",
                table: "Rings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RingImagePath",
                table: "Rings",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "RingId",
                table: "Rings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NecklaceName",
                table: "Necklaces",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NecklaceImagePath",
                table: "Necklaces",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "NecklaceId",
                table: "Necklaces",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MetalBarName",
                table: "MetalBars",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MetalBarImagePath",
                table: "MetalBars",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "BarId",
                table: "MetalBars",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DiamondName",
                table: "InvestmentDiamonds",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DiamondImagePath",
                table: "InvestmentDiamonds",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "DiamondId",
                table: "InvestmentDiamonds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CoinName",
                table: "InvestmentCoins",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CoinImagePath",
                table: "InvestmentCoins",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "CoinId",
                table: "InvestmentCoins",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rings",
                newName: "RingName");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Rings",
                newName: "RingImagePath");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rings",
                newName: "RingId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Necklaces",
                newName: "NecklaceName");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Necklaces",
                newName: "NecklaceImagePath");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Necklaces",
                newName: "NecklaceId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MetalBars",
                newName: "MetalBarName");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "MetalBars",
                newName: "MetalBarImagePath");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MetalBars",
                newName: "BarId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "InvestmentDiamonds",
                newName: "DiamondName");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "InvestmentDiamonds",
                newName: "DiamondImagePath");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InvestmentDiamonds",
                newName: "DiamondId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "InvestmentCoins",
                newName: "CoinName");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "InvestmentCoins",
                newName: "CoinImagePath");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InvestmentCoins",
                newName: "CoinId");
        }
    }
}

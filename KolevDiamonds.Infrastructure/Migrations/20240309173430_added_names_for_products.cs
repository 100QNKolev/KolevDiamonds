using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class added_names_for_products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoindId",
                table: "InvestmentCoins",
                newName: "CoinId");

            migrationBuilder.AlterColumn<string>(
                name: "Purity",
                table: "Rings",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "Purity of the metal expressed in carat for gold or sample for silver",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Purity of the metal expressed in carat for gold or sample for silver");

            migrationBuilder.AddColumn<string>(
                name: "RingName",
                table: "Rings",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "",
                comment: "Name of the ring");

            migrationBuilder.AlterColumn<string>(
                name: "Purity",
                table: "Necklaces",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "Purity of the metal expressed in carat for gold or sample for silver",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Purity of the metal expressed in carat for gold or sample for silver");

            migrationBuilder.AddColumn<string>(
                name: "NecklaceName",
                table: "Necklaces",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "",
                comment: "Name of the necklace");

            migrationBuilder.AlterColumn<string>(
                name: "Purity",
                table: "MetalBars",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "Purity of the metal expressed in carat for gold or sample for silver",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Purity of the metal expressed in carat for gold or sample for silver");

            migrationBuilder.AlterColumn<string>(
                name: "Dimensions",
                table: "MetalBars",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Dimensions of the metal bar (length x width)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Dimensions of the metal bar (length x width)");

            migrationBuilder.AddColumn<string>(
                name: "MetalBarName",
                table: "MetalBars",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "",
                comment: "Name of the metal bar");

            migrationBuilder.AlterColumn<string>(
                name: "Proportions",
                table: "InvestmentDiamonds",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The proportions of the diamond",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "The proportions of the diamond");

            migrationBuilder.AlterColumn<string>(
                name: "CertifyingLaboratory",
                table: "InvestmentDiamonds",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "The certifying gemological laboratory",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "The certifying gemological laboratory");

            migrationBuilder.AddColumn<string>(
                name: "DiamondName",
                table: "InvestmentDiamonds",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "",
                comment: "Name of the diamond");

            migrationBuilder.AlterColumn<string>(
                name: "Packaging",
                table: "InvestmentCoins",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Packaging for the coin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Packaging for the coin");

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "InvestmentCoins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Manufacturer of the coin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Manufacturer of the coin");

            migrationBuilder.AlterColumn<string>(
                name: "LegalTender",
                table: "InvestmentCoins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Legal tender value in the specified currency",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Legal tender value in the specified currency");

            migrationBuilder.AddColumn<string>(
                name: "CoinName",
                table: "InvestmentCoins",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "",
                comment: "Name of the coin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RingName",
                table: "Rings");

            migrationBuilder.DropColumn(
                name: "NecklaceName",
                table: "Necklaces");

            migrationBuilder.DropColumn(
                name: "MetalBarName",
                table: "MetalBars");

            migrationBuilder.DropColumn(
                name: "DiamondName",
                table: "InvestmentDiamonds");

            migrationBuilder.DropColumn(
                name: "CoinName",
                table: "InvestmentCoins");

            migrationBuilder.RenameColumn(
                name: "CoinId",
                table: "InvestmentCoins",
                newName: "CoindId");

            migrationBuilder.AlterColumn<string>(
                name: "Purity",
                table: "Rings",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Purity of the metal expressed in carat for gold or sample for silver",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "Purity of the metal expressed in carat for gold or sample for silver");

            migrationBuilder.AlterColumn<string>(
                name: "Purity",
                table: "Necklaces",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Purity of the metal expressed in carat for gold or sample for silver",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "Purity of the metal expressed in carat for gold or sample for silver");

            migrationBuilder.AlterColumn<string>(
                name: "Purity",
                table: "MetalBars",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Purity of the metal expressed in carat for gold or sample for silver",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "Purity of the metal expressed in carat for gold or sample for silver");

            migrationBuilder.AlterColumn<string>(
                name: "Dimensions",
                table: "MetalBars",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Dimensions of the metal bar (length x width)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Dimensions of the metal bar (length x width)");

            migrationBuilder.AlterColumn<string>(
                name: "Proportions",
                table: "InvestmentDiamonds",
                type: "nvarchar(max)",
                nullable: false,
                comment: "The proportions of the diamond",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The proportions of the diamond");

            migrationBuilder.AlterColumn<string>(
                name: "CertifyingLaboratory",
                table: "InvestmentDiamonds",
                type: "nvarchar(max)",
                nullable: false,
                comment: "The certifying gemological laboratory",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "The certifying gemological laboratory");

            migrationBuilder.AlterColumn<string>(
                name: "Packaging",
                table: "InvestmentCoins",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Packaging for the coin",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Packaging for the coin");

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "InvestmentCoins",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Manufacturer of the coin",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Manufacturer of the coin");

            migrationBuilder.AlterColumn<string>(
                name: "LegalTender",
                table: "InvestmentCoins",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Legal tender value in the specified currency",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Legal tender value in the specified currency");
        }
    }
}

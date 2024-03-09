using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class fixed_naming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_metalBars",
                table: "metalBars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_investmentDiamonds",
                table: "investmentDiamonds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_investmentCoins",
                table: "investmentCoins");

            migrationBuilder.RenameTable(
                name: "metalBars",
                newName: "MetalBars");

            migrationBuilder.RenameTable(
                name: "investmentDiamonds",
                newName: "InvestmentDiamonds");

            migrationBuilder.RenameTable(
                name: "investmentCoins",
                newName: "InvestmentCoins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetalBars",
                table: "MetalBars",
                column: "BarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvestmentDiamonds",
                table: "InvestmentDiamonds",
                column: "DiamondId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvestmentCoins",
                table: "InvestmentCoins",
                column: "CoindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MetalBars",
                table: "MetalBars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvestmentDiamonds",
                table: "InvestmentDiamonds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvestmentCoins",
                table: "InvestmentCoins");

            migrationBuilder.RenameTable(
                name: "MetalBars",
                newName: "metalBars");

            migrationBuilder.RenameTable(
                name: "InvestmentDiamonds",
                newName: "investmentDiamonds");

            migrationBuilder.RenameTable(
                name: "InvestmentCoins",
                newName: "investmentCoins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_metalBars",
                table: "metalBars",
                column: "BarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_investmentDiamonds",
                table: "investmentDiamonds",
                column: "DiamondId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_investmentCoins",
                table: "investmentCoins",
                column: "CoindId");
        }
    }
}

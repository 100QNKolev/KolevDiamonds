using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class Added_IsForSale_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsForSale",
                table: "Rings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the item for sale");

            migrationBuilder.AddColumn<bool>(
                name: "IsForSale",
                table: "Necklaces",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the item for sale");

            migrationBuilder.AddColumn<bool>(
                name: "IsForSale",
                table: "MetalBars",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the item for sale");

            migrationBuilder.AddColumn<bool>(
                name: "IsForSale",
                table: "InvestmentDiamonds",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the item for sale");

            migrationBuilder.AddColumn<bool>(
                name: "IsForSale",
                table: "InvestmentCoins",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the item for sale");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b092b9aa-0fe6-4dba-b887-e62fd111266c", "AQAAAAEAACcQAAAAEHcGwGUFUxgWCulgaSOSYFCnfnNCjiIoFi0PVUq4KujjOPdrAReKYLN+k+dsEQq8zQ==", "df36812e-1754-49cc-9850-a648c2451a6d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsForSale",
                table: "Rings");

            migrationBuilder.DropColumn(
                name: "IsForSale",
                table: "Necklaces");

            migrationBuilder.DropColumn(
                name: "IsForSale",
                table: "MetalBars");

            migrationBuilder.DropColumn(
                name: "IsForSale",
                table: "InvestmentDiamonds");

            migrationBuilder.DropColumn(
                name: "IsForSale",
                table: "InvestmentCoins");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28be4f26-f7e4-4910-8e57-6971a7a08df0", "AQAAAAEAACcQAAAAEFMScpn8YzQ3w22rafzSKpg6yY2qbrmkbcyFnjZv9DmjR2CrkFhNYv2kCKelYr0hlg==", "de5c571a-1ee5-4ba3-bdc4-7d8e6da419c8" });
        }
    }
}

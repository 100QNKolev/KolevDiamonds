using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class Added_IsForSale_column_default_value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "579a726f-c323-444b-96d3-38f50f4a1d12", "AQAAAAEAACcQAAAAENYrsaT1djg198+3ncL0Yy5FYXIqDPln1TtchznbyX0B0zu2ci8WvTfjoP4p51ALFw==", "20ad91b7-5525-4543-864c-75cbb4456e17" });

            migrationBuilder.UpdateData(
                table: "InvestmentCoins",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "InvestmentCoins",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "InvestmentCoins",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "InvestmentDiamonds",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "InvestmentDiamonds",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "InvestmentDiamonds",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "MetalBars",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "MetalBars",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "MetalBars",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Necklaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Necklaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Necklaces",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsForSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsForSale",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b092b9aa-0fe6-4dba-b887-e62fd111266c", "AQAAAAEAACcQAAAAEHcGwGUFUxgWCulgaSOSYFCnfnNCjiIoFi0PVUq4KujjOPdrAReKYLN+k+dsEQq8zQ==", "df36812e-1754-49cc-9850-a648c2451a6d" });

            migrationBuilder.UpdateData(
                table: "InvestmentCoins",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "InvestmentCoins",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "InvestmentCoins",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "InvestmentDiamonds",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "InvestmentDiamonds",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "InvestmentDiamonds",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "MetalBars",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "MetalBars",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "MetalBars",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "Necklaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "Necklaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "Necklaces",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsForSale",
                value: false);

            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsForSale",
                value: false);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class AdminTest4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28be4f26-f7e4-4910-8e57-6971a7a08df0", "AQAAAAEAACcQAAAAEFMScpn8YzQ3w22rafzSKpg6yY2qbrmkbcyFnjZv9DmjR2CrkFhNYv2kCKelYr0hlg==", "de5c571a-1ee5-4ba3-bdc4-7d8e6da419c8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a72eaab-c5b8-490e-a617-06f395d8f495", "AQAAAAEAACcQAAAAEPqcKUXwEXoVo3cQ+UKoUebRQT9CD7cRIqAZa2u0Jggusikok3LL87ZaeatpKsj2Yg==", "1a423305-96c1-42e5-a894-4a09ead6b79a" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class AdminTest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a72eaab-c5b8-490e-a617-06f395d8f495", "AQAAAAEAACcQAAAAEPqcKUXwEXoVo3cQ+UKoUebRQT9CD7cRIqAZa2u0Jggusikok3LL87ZaeatpKsj2Yg==", "1a423305-96c1-42e5-a894-4a09ead6b79a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adfda1e7-37e0-4dc4-9726-52e20032c1c7", "AQAAAAEAACcQAAAAEH/n9KcG0rUdVigq06EVBBea/zVCFCoUuGMjDWyuJhqzp4DOXGqkvW0oD/LvTQUAAA==", "0f70be1a-7497-4185-b7af-f004fbb3fce2" });
        }
    }
}

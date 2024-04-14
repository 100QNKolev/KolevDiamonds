using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class AdminTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adfda1e7-37e0-4dc4-9726-52e20032c1c7", "AQAAAAEAACcQAAAAEH/n9KcG0rUdVigq06EVBBea/zVCFCoUuGMjDWyuJhqzp4DOXGqkvW0oD/LvTQUAAA==", "0f70be1a-7497-4185-b7af-f004fbb3fce2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bff4a00-9809-453a-84fa-2fb15bffe9c6", "AQAAAAEAACcQAAAAEFTWuZ8+7Bbntv0w6d/AiammuA5wytXfrlmnOIgyMYcl/dA0czxXKngov+kwG2aazQ==", "17feaedd-d9b9-4384-9ad8-3395bde6fbd0" });
        }
    }
}

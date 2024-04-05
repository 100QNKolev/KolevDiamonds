using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class AdminTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bff4a00-9809-453a-84fa-2fb15bffe9c6", "AQAAAAEAACcQAAAAEFTWuZ8+7Bbntv0w6d/AiammuA5wytXfrlmnOIgyMYcl/dA0czxXKngov+kwG2aazQ==", "17feaedd-d9b9-4384-9ad8-3395bde6fbd0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9335a540-c8df-483c-a42f-ca016f7a06fd", "AQAAAAEAACcQAAAAEMIDobjI3gJkJRI6/cVu+JGZsH9QeHDNWm9xBoP0sZH6Yvl5CCwxdcXALQ9XuEAw4A==", "c6fe2474-e5b1-41ca-957d-7e15e32b90a4" });
        }
    }
}

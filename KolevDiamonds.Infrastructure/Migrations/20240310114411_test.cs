using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rings",
                columns: new[] { "RingId", "Carats", "Clarity", "Colour", "Cut", "Metal", "Price", "Purity", "RingImagePath", "RingName" },
                values: new object[] { 1, 1.5, 5, 4, 2, 2, 1000.00m, "18K", "/images/ring1.jpg", "Gold Diamond Ring" });

            migrationBuilder.InsertData(
                table: "Rings",
                columns: new[] { "RingId", "Carats", "Clarity", "Colour", "Cut", "Metal", "Price", "Purity", "RingImagePath", "RingName" },
                values: new object[] { 2, 4.0, 3, 4, 1, 2, 10020.00m, "18K", "/images/ring2.jpg", "Gold Ring With Crown Diamond" });

            migrationBuilder.InsertData(
                table: "Rings",
                columns: new[] { "RingId", "Carats", "Clarity", "Colour", "Cut", "Metal", "Price", "Purity", "RingImagePath", "RingName" },
                values: new object[] { 3, 3.0, 5, 4, 1, 4, 12000.00m, "18K", "/images/ring3.jpg", "Rose Gold Diamond Ring" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rings",
                keyColumn: "RingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rings",
                keyColumn: "RingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rings",
                keyColumn: "RingId",
                keyValue: 3);
        }
    }
}

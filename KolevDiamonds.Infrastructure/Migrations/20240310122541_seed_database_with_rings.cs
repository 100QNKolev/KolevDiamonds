using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class seed_database_with_rings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "RingId",
                keyValue: 1,
                column: "RingImagePath",
                value: "https://www.tanishq.co.in/on/demandware.static/-/Sites-Tanishq-product-catalog/default/dw5721e8ec/images/hi-res/50D2FFFFRAA02_1.jpg");

            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "RingId",
                keyValue: 2,
                column: "RingImagePath",
                value: "https://4.imimg.com/data4/QW/YU/FUSIONI-3520335/prod-image.jpg");

            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "RingId",
                keyValue: 3,
                column: "RingImagePath",
                value: "https://love-and-co.com/cdn/shop/files/CR591-LGD_lifestyle.jpg?v=1697793277&width=2000");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "RingId",
                keyValue: 1,
                column: "RingImagePath",
                value: "/images/ring1.jpg");

            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "RingId",
                keyValue: 2,
                column: "RingImagePath",
                value: "/images/ring2.jpg");

            migrationBuilder.UpdateData(
                table: "Rings",
                keyColumn: "RingId",
                keyValue: 3,
                column: "RingImagePath",
                value: "/images/ring3.jpg");
        }
    }
}

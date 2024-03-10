using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class seeded_db_with_products_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InvestmentCoins",
                columns: new[] { "CoinId", "Circulation", "CoinImagePath", "CoinName", "Diameter", "LegalTender", "Manufacturer", "Metal", "Packaging", "Price", "Purity", "Quality", "Weight" },
                values: new object[,]
                {
                    { 1, 10000, "https://upload.wikimedia.org/wikipedia/commons/3/3a/1959_sovereign_Elizabeth_II_obverse.jpg", "Gold Sovereign", 22.050000000000001, "GBP 1", "The Royal Mint", 2, "Protective Capsule", 1000.00m, 0.91669999999999996, 1, 7.9800000000000004 },
                    { 2, 5000, "https://assets.goldeneaglecoin.com/resource/productimages/2020-SE-obv.jpg", "Silver Eagle", 40.600000000000001, "USD 1", "United States Mint", 1, "Plastic Tube", 50.00m, 0.999, 1, 31.100000000000001 },
                    { 3, 1000, "https://media.tavid.ee/v7/_product_catalog_/1-oz-canadian-maple-leaf-silver-coin/canadian_maple_leaf_1oz_silver_coin_reverse.jpg?height=960&width=960&func=cropfit", "Silver Maple Leaf", 30.0, "CAD 50", "Royal Canadian Mint", 1, "Assay Card", 500.00m, 0.99950000000000006, 3, 31.100000000000001 }
                });

            migrationBuilder.InsertData(
                table: "InvestmentDiamonds",
                columns: new[] { "DiamondId", "Carats", "CertifyingLaboratory", "Clarity", "Colour", "Cut", "DiamondImagePath", "DiamondName", "Price", "Proportions" },
                values: new object[,]
                {
                    { 1, 1.0, "GIA", 3, 2, 1, "https://www.diamondbanc.com/wp-content/uploads/2019/01/shutterstock_32731492-1024x681.jpg", "Round Brilliant Diamond", 5000.00m, "Excellent" },
                    { 2, 1.5, "IGI", 6, 4, 2, "https://www.qualitydiamonds.co.uk/media/1132/princess-diamond-top.png", "Princess Cut Diamond", 7000.00m, "Very Good" },
                    { 3, 2.0, "HRD", 7, 3, 3, "https://www.capediamonds.co.za/wp-content/uploads/2020/09/Emerald-Cut-Diamonds-Cape-Diamonds-Cape-Town-South-Africa.jpg", "Emerald Cut Diamond", 10000.00m, "Good" }
                });

            migrationBuilder.InsertData(
                table: "MetalBars",
                columns: new[] { "BarId", "Dimensions", "Metal", "MetalBarImagePath", "MetalBarName", "Price", "Purity", "Weight" },
                values: new object[,]
                {
                    { 1, "27 x 47 mm", 2, "https://m.media-amazon.com/images/I/61ICiCEk3TL._AC_UF894,1000_QL80_.jpg", "Gold Bar", 15000.00m, "24 Karat", 1000.0 },
                    { 2, "20 x 40 mm", 1, "https://www.monex.com/wp-content/uploads/2023/06/1-kilo-silver-bar-side.png", "Silver Bar", 500.00m, "999.9/1000", 1000.0 },
                    { 3, "25 x 50 mm", 4, "https://images.squarespace-cdn.com/content/v1/5719f32620c64744b886bcd2/1612970177011-TLIGBQ4ZDOODFX0TOR42/rose-gold-bar.png", "Rose Gold Bar", 20000.00m, "24 Karat", 1000.0 }
                });

            migrationBuilder.InsertData(
                table: "Necklaces",
                columns: new[] { "NecklaceId", "Carats", "Clarity", "Colour", "Cut", "Length", "Metal", "NecklaceImagePath", "NecklaceName", "Price", "Purity" },
                values: new object[,]
                {
                    { 1, 2.5, 5, 4, 1, 450.0, 2, "https://i.etsystatic.com/6244698/r/il/8121e9/1697727663/il_570xN.1697727663_9elj.jpg", "Diamond Solitaire Necklace", 1500.00m, "18K" },
                    { 2, 3.0, 7, 14, 2, 500.0, 1, "https://media.beaverbrooks.co.uk/i/beaverbrooks/G105854_0", "Sapphire Halo Necklace", 2000.00m, "925" },
                    { 3, 2.7999999999999998, 4, 1, 1, 480.0, 1, "https://haverhill.com/cdn/shop/products/image_11085d78-83fb-429b-a153-15a90bc9ee30_1200x1200.jpg?v=1705428203", "Emerald Pendant Necklace", 1800.00m, "925" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvestmentCoins",
                keyColumn: "CoinId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InvestmentCoins",
                keyColumn: "CoinId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InvestmentCoins",
                keyColumn: "CoinId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InvestmentDiamonds",
                keyColumn: "DiamondId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InvestmentDiamonds",
                keyColumn: "DiamondId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InvestmentDiamonds",
                keyColumn: "DiamondId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MetalBars",
                keyColumn: "BarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MetalBars",
                keyColumn: "BarId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MetalBars",
                keyColumn: "BarId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Necklaces",
                keyColumn: "NecklaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Necklaces",
                keyColumn: "NecklaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Necklaces",
                keyColumn: "NecklaceId",
                keyValue: 3);
        }
    }
}

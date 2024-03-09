using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class added_needed_database_classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "investmentCoins",
                columns: table => new
                {
                    CoindId = table.Column<int>(type: "int", nullable: false, comment: "Coin unique identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metal = table.Column<int>(type: "int", nullable: false, comment: "Type of metal"),
                    Weight = table.Column<double>(type: "float", nullable: false, comment: "Weight of the metal in grams"),
                    Purity = table.Column<double>(type: "float", nullable: false, comment: "Purity of the metal expressed as a ratio"),
                    Quality = table.Column<int>(type: "int", nullable: false, comment: "Quality of the metal"),
                    Circulation = table.Column<int>(type: "int", nullable: false, comment: "Number of pieces in circulation"),
                    Diameter = table.Column<double>(type: "float", nullable: false, comment: "Diameter of the coin in millimeters"),
                    LegalTender = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Legal tender value in the specified currency"),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Manufacturer of the coin"),
                    Packaging = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Packaging for the coin")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_investmentCoins", x => x.CoindId);
                },
                comment: "Investment coin specifications");

            migrationBuilder.CreateTable(
                name: "investmentDiamonds",
                columns: table => new
                {
                    DiamondId = table.Column<int>(type: "int", nullable: false, comment: "Diamond unique identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carats = table.Column<double>(type: "float", nullable: false, comment: "How much carats is the diamond"),
                    Colour = table.Column<int>(type: "int", nullable: false, comment: "What color is the diamond"),
                    Clarity = table.Column<int>(type: "int", nullable: false, comment: "What clarity is the diamond"),
                    Cut = table.Column<int>(type: "int", nullable: false, comment: "How well the diamond is cut"),
                    CertifyingLaboratory = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The certifying gemological laboratory"),
                    Proportions = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The proportions of the diamond")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_investmentDiamonds", x => x.DiamondId);
                },
                comment: "Investment diamond specifications");

            migrationBuilder.CreateTable(
                name: "metalBars",
                columns: table => new
                {
                    BarId = table.Column<int>(type: "int", nullable: false, comment: "Metal bar unique identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metal = table.Column<int>(type: "int", nullable: false, comment: "Type of metal"),
                    Weight = table.Column<double>(type: "float", nullable: false, comment: "Weight of the metal bar"),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Dimensions of the metal bar (length x width)"),
                    Purity = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Purity of the metal expressed in carat for gold or sample for silver")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metalBars", x => x.BarId);
                },
                comment: "Metal bar specifications");

            migrationBuilder.CreateTable(
                name: "Necklaces",
                columns: table => new
                {
                    NecklaceId = table.Column<int>(type: "int", nullable: false, comment: "Necklace unique identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metal = table.Column<int>(type: "int", nullable: false, comment: "Metal, which necklace is made of"),
                    Carats = table.Column<double>(type: "float", nullable: false, comment: "How much carats is the main diamond used in the necklace"),
                    Colour = table.Column<int>(type: "int", nullable: false, comment: "What color is the main diamond"),
                    Clarity = table.Column<int>(type: "int", nullable: false, comment: "What clarity is the main diamond in the necklace"),
                    Cut = table.Column<int>(type: "int", nullable: false, comment: "How well the diamond is cut"),
                    Purity = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Purity of the metal expressed in carat for gold or sample for silver"),
                    Length = table.Column<double>(type: "float", nullable: false, comment: "Length of the necklace in millimeters")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Necklaces", x => x.NecklaceId);
                },
                comment: "Necklace specifications");

            migrationBuilder.CreateTable(
                name: "Rings",
                columns: table => new
                {
                    RingId = table.Column<int>(type: "int", nullable: false, comment: "Ring unique identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metal = table.Column<int>(type: "int", nullable: false, comment: "Metal, which ring is made of"),
                    Carats = table.Column<double>(type: "float", nullable: false, comment: "How much carats is the main diamond used in the ring"),
                    Colour = table.Column<int>(type: "int", nullable: false, comment: "What color is the main diamond"),
                    Clarity = table.Column<int>(type: "int", nullable: false, comment: "What clarity is the main diamond in the ring"),
                    Cut = table.Column<int>(type: "int", nullable: false, comment: "How well the diamond is cut"),
                    Purity = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Purity of the metal expressed in carat for gold or sample for silver")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rings", x => x.RingId);
                },
                comment: "Ring specifications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "investmentCoins");

            migrationBuilder.DropTable(
                name: "investmentDiamonds");

            migrationBuilder.DropTable(
                name: "metalBars");

            migrationBuilder.DropTable(
                name: "Necklaces");

            migrationBuilder.DropTable(
                name: "Rings");
        }
    }
}

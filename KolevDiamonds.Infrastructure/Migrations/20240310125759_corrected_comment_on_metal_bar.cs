using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    public partial class corrected_comment_on_metal_bar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "MetalBars",
                type: "float",
                nullable: false,
                comment: "Weight of the metal bar in grams",
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Weight of the metal bar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "MetalBars",
                type: "float",
                nullable: false,
                comment: "Weight of the metal bar",
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Weight of the metal bar in grams");
        }
    }
}

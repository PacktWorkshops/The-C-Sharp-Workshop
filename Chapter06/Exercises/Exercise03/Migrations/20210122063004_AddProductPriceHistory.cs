using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chapter06.Exercises.Exercise03.Migrations
{
    public partial class AddProductPriceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "Factory",
                table: "Product");

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundedAt",
                schema: "Factory",
                table: "Manufacturer",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ProductPriceHistory",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    DateOfPrice = table.Column<DateTime>(type: "date", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPriceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPriceHistory_Product",
                        column: x => x.ProductId,
                        principalSchema: "Factory",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceHistory_ProductId",
                schema: "Factory",
                table: "ProductPriceHistory",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPriceHistory",
                schema: "Factory");

            migrationBuilder.DropColumn(
                name: "FoundedAt",
                schema: "Factory",
                table: "Manufacturer");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "Factory",
                table: "Product",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

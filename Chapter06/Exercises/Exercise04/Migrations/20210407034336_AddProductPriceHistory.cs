using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Chapter06.Exercises.Exercise04.Migrations
{
    public partial class AddProductPriceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "Factory",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "ProductPriceHistory",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    DateOfPrice = table.Column<DateTime>(type: "date", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "Factory",
                table: "Product",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

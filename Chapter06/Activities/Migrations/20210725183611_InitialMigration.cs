using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Chapter06.Activities.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TruckLogistics");

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "TruckLogistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    DoB = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                schema: "TruckLogistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    YearOfMaking = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TruckDispatch",
                schema: "TruckLogistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    TruckId = table.Column<int>(type: "integer", nullable: false),
                    CurrentLocation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Deadline = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckDispatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TruckDispatch_Person_DriverId",
                        column: x => x.DriverId,
                        principalSchema: "TruckLogistics",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TruckDispatch_Truck_TruckId",
                        column: x => x.TruckId,
                        principalSchema: "TruckLogistics",
                        principalTable: "Truck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TruckDispatch_DriverId",
                schema: "TruckLogistics",
                table: "TruckDispatch",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckDispatch_TruckId",
                schema: "TruckLogistics",
                table: "TruckDispatch",
                column: "TruckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckDispatch",
                schema: "TruckLogistics");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "TruckLogistics");

            migrationBuilder.DropTable(
                name: "Truck",
                schema: "TruckLogistics");
        }
    }
}

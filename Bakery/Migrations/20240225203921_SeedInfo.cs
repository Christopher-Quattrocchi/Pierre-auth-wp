using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery.Migrations
{
    public partial class SeedInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flavors",
                columns: new[] { "FlavorId", "Name" },
                values: new object[,]
                {
                    { 1, "Savory" },
                    { 2, "Sweet" }
                });

            migrationBuilder.InsertData(
                table: "Treats",
                columns: new[] { "TreatId", "Name" },
                values: new object[,]
                {
                    { 1, "Croissant" },
                    { 2, "Chocolate Croissant" },
                    { 3, "Sourdough Bread" }
                });

            migrationBuilder.InsertData(
                table: "FlavorTreats",
                columns: new[] { "FlavorTreatId", "FlavorId", "TreatId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "FlavorTreats",
                columns: new[] { "FlavorTreatId", "FlavorId", "TreatId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "FlavorTreats",
                columns: new[] { "FlavorTreatId", "FlavorId", "TreatId" },
                values: new object[] { 3, 1, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FlavorTreats",
                keyColumn: "FlavorTreatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FlavorTreats",
                keyColumn: "FlavorTreatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FlavorTreats",
                keyColumn: "FlavorTreatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flavors",
                keyColumn: "FlavorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flavors",
                keyColumn: "FlavorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Treats",
                keyColumn: "TreatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Treats",
                keyColumn: "TreatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Treats",
                keyColumn: "TreatId",
                keyValue: 3);
        }
    }
}

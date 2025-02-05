using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HendrixSOSResources.Migrations
{
    /// <inheritdoc />
    public partial class SeedResources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "Description", "Name", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, "Various sizes of bandages", "Bandages", 100, 0 },
                    { 2, "Alcohol-based antiseptic wipes", "Antiseptic Wipes", 200, 0 },
                    { 3, "Ibuprofen and acetaminophen", "Pain Relievers", 150, 1 },
                    { 4, "Cough suppressant syrup", "Cough Syrup", 50, 1 },
                    { 5, "Fluoride toothpaste", "Toothpaste", 75, 2 },
                    { 6, "Gentle shampoo for daily use", "Shampoo", 60, 2 },
                    { 7, "Antiperspirant deodorant", "Deodorant", 80, 3 },
                    { 8, "Moisturizing lotion", "Lotion", 90, 3 },
                    { 9, "Advanced calculus textbook", "Calculus Textbook", 30, 4 },
                    { 10, "Introductory biology textbook", "Biology Textbook", 40, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: 10);
        }
    }
}

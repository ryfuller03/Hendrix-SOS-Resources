using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HendrixSOSResources.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    CampusEmail = table.Column<string>(type: "TEXT", nullable: false),
                    HendrixID = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Classification = table.Column<int>(type: "INTEGER", nullable: false),
                    CampusAddress = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    EmFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    EmLastName = table.Column<string>(type: "TEXT", nullable: false),
                    EmEmail = table.Column<string>(type: "TEXT", nullable: false),
                    EmPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    EmRelationship = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentEmployer = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentEmployerPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    JobPosition = table.Column<string>(type: "TEXT", nullable: false),
                    Pay = table.Column<int>(type: "INTEGER", nullable: false),
                    PayPeriod = table.Column<int>(type: "INTEGER", nullable: false),
                    MonthlyWages = table.Column<decimal>(type: "TEXT", nullable: true),
                    FinAidStatement = table.Column<string>(type: "TEXT", nullable: false),
                    ReferredBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.CampusEmail);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NeedWithin24Hours = table.Column<bool>(type: "INTEGER", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    ResourceId = table.Column<int>(type: "INTEGER", nullable: false),
                    CampusEmail = table.Column<string>(type: "TEXT", nullable: false),
                    ProfileCampusEmail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Profiles_ProfileCampusEmail",
                        column: x => x.ProfileCampusEmail,
                        principalTable: "Profiles",
                        principalColumn: "CampusEmail");
                    table.ForeignKey(
                        name: "FK_Requests_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Resources",
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

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ProfileCampusEmail",
                table: "Requests",
                column: "ProfileCampusEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ResourceId",
                table: "Requests",
                column: "ResourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}

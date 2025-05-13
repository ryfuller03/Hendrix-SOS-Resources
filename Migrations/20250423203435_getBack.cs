using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HendrixSOSResources.Migrations
{
    /// <inheritdoc />
    public partial class getBack : Migration
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
                    Reason = table.Column<string>(type: "TEXT", nullable: true),
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
                table: "Profiles",
                columns: new[] { "CampusEmail", "CampusAddress", "Classification", "CurrentEmployer", "CurrentEmployerPhoneNumber", "EmEmail", "EmFirstName", "EmLastName", "EmPhoneNumber", "EmRelationship", "Email", "FinAidStatement", "FirstName", "HendrixID", "JobPosition", "LastName", "MonthlyWages", "Pay", "PayPeriod", "PhoneNumber", "ReferredBy" },
                values: new object[,]
                {
                    { "prof.evans@hendrix.edu", "Ellis Hall, Room 305", 5, "Hendrix College", "501-450-1000", "frank.evans@email.com", "Frank", "Evans", "501-222-3344", "Brother", "emily.evans@hendrix.edu", "null", "Emily", 3010, "Professor of Biology", "Evans", 6000.00m, 1, 6, "501-333-9999", "Department Chair" },
                    { "staff.jones@hendrix.edu", "Admin Building, Office 210", 6, "Hendrix College", "501-450-1000", "diana.jones@email.com", "Diana", "Jones", "501-777-8899", "Spouse", "charlie.jones@work.com", "null", "Charlie", 2005, "Administrative Assistant", "Jones", 3500.00m, 1, 4, "501-555-1212", "Human Resources" },
                    { "student1@hendrix.edu", "Veasey Hall 101", 0, "null", "null", "bob.smith@email.com", "Bob", "Smith", "501-987-6543", "Father", "alice.smith@email.com", "Receiving partial financial aid.", "Alice", 1001, "null", "Smith", 15m, 0, 7, "501-123-4567", "Orientation Leader" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ID", "Description", "Name", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, "Various sizes of bandages", "Bandages", 100, 4 },
                    { 2, "Alcohol-based antiseptic wipes", "Antiseptic Wipes", 200, 4 },
                    { 3, "Ibuprofen and acetaminophen", "Pain Relievers", 150, 4 },
                    { 4, "Cough suppressant syrup", "Cough Syrup", 50, 4 },
                    { 5, "Fluoride toothpaste", "Toothpaste", 75, 1 },
                    { 6, "Gentle shampoo for daily use", "Shampoo", 60, 1 },
                    { 7, "Antiperspirant deodorant", "Deodorant", 80, 1 },
                    { 8, "Moisturizing lotion", "Lotion", 90, 1 },
                    { 9, "Advanced calculus textbook", "Calculus Textbook", 30, 7 },
                    { 10, "Introductory biology textbook", "Biology Textbook", 40, 7 }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "CampusEmail", "CreatedAt", "NeedWithin24Hours", "ProfileCampusEmail", "Reason", "ResourceId", "Status" },
                values: new object[,]
                {
                    { 1, "student1@hendrix.edu", new DateTime(2025, 4, 21, 15, 34, 34, 727, DateTimeKind.Local).AddTicks(160), true, null, "Scraped my knee playing intramurals.", 1, 0 },
                    { 2, "student1@hendrix.edu", new DateTime(2025, 4, 18, 15, 34, 34, 727, DateTimeKind.Local).AddTicks(170), false, null, "Ran out of toothpaste.", 5, 1 },
                    { 3, "staff.jones@hendrix.edu", new DateTime(2025, 4, 22, 15, 34, 34, 727, DateTimeKind.Local).AddTicks(200), false, null, "Dealing with a headache.", 3, 0 },
                    { 4, "prof.evans@hendrix.edu", new DateTime(2025, 4, 16, 15, 34, 34, 727, DateTimeKind.Local).AddTicks(220), false, null, "For my lab's first aid kit.", 2, 1 }
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

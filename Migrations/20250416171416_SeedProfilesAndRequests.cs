using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HendrixSOSResources.Migrations
{
    /// <inheritdoc />
    public partial class SeedProfilesAndRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Requests",
                columns: new[] { "Id", "CampusEmail", "CreatedAt", "NeedWithin24Hours", "ProfileCampusEmail", "Reason", "ResourceId", "Status" },
                values: new object[,]
                {
                    { 1, "student1@hendrix.edu", new DateTime(2025, 4, 14, 12, 14, 16, 110, DateTimeKind.Local).AddTicks(4470), true, null, "Scraped my knee playing intramurals.", 1, 0 },
                    { 2, "student1@hendrix.edu", new DateTime(2025, 4, 11, 12, 14, 16, 110, DateTimeKind.Local).AddTicks(4490), false, null, "Ran out of toothpaste.", 5, 1 },
                    { 3, "staff.jones@hendrix.edu", new DateTime(2025, 4, 15, 12, 14, 16, 110, DateTimeKind.Local).AddTicks(4520), false, null, "Dealing with a headache.", 3, 0 },
                    { 4, "prof.evans@hendrix.edu", new DateTime(2025, 4, 9, 12, 14, 16, 110, DateTimeKind.Local).AddTicks(4550), false, null, "For my lab's first aid kit.", 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "CampusEmail",
                keyValue: "prof.evans@hendrix.edu");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "CampusEmail",
                keyValue: "staff.jones@hendrix.edu");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "CampusEmail",
                keyValue: "student1@hendrix.edu");

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

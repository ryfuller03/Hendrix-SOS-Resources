using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HendrixSOSResources.Migrations
{
    /// <inheritdoc />
    public partial class RemovedEmailTagFromEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 15, 24, 20, 743, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 18, 15, 24, 20, 743, DateTimeKind.Local).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 22, 15, 24, 20, 743, DateTimeKind.Local).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 16, 15, 24, 20, 743, DateTimeKind.Local).AddTicks(5830));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 14, 15, 46, 54, 941, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 11, 15, 46, 54, 941, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 15, 15, 46, 54, 941, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 15, 46, 54, 941, DateTimeKind.Local).AddTicks(6170));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOSResources.Migrations
{
    /// <inheritdoc />
    public partial class TextbooksByADifName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Departments",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Edition",
                table: "Departments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Departments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Edition",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Departments",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Departments",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Departments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

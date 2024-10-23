using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOSResources.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PayType",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "PayType",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}

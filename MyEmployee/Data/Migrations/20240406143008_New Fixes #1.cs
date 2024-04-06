using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyEmployee.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFixes1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Color", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c4f7a115-924e-46d0-891e-76fc0df2a72b", "#72b5a8", null, "ApplicationRole", "Admin", "ADMIN" },
                    { "d278a7a5-d948-4e16-820a-acf8b21e09cc", "#86918f", null, "ApplicationRole", "User", "USER" },
                    { "d6f787b6-c854-4eaa-98f7-69acdb4da3ca", "#88b892", null, "ApplicationRole", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4f7a115-924e-46d0-891e-76fc0df2a72b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d278a7a5-d948-4e16-820a-acf8b21e09cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6f787b6-c854-4eaa-98f7-69acdb4da3ca");
        }
    }
}

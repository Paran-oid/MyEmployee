using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyEmployee.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFixes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Color", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "#88b892", null, "ApplicationRole", "Manager", "MANAGER" },
                    { "2", "#72b5a8", null, "ApplicationRole", "Admin", "ADMIN" },
                    { "3", "#86918f", null, "ApplicationRole", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "0d797335-effd-4baf-8c5a-1be201256d6d", "aziz@example.com", false, "Aziz", "Hmidi", false, null, "AZIZ@EXAMPLE.COM", null, "AQAAAAIAAYagAAAAEJVg+CdaBG/DYTLulGX3S0CK5GyKTyP5Ht3mdW076sr+3OifwaqqOE/DJqfguWLusg==", null, false, "058c0eee-8f43-425a-8e7b-eaf96925dfa5", false, "Paranoid" },
                    { "2", 0, "28491d91-686c-42c5-a6da-03e7a995c263", "arslen@example.com", false, "Arslen", "Chabaanie", false, null, "ARSLEN@EXAMPLE.COM", null, "AQAAAAIAAYagAAAAEOE3jXh45b9Sguv1bzy9mHm72gwAXsPV0WuTSwhiLoSH3LxUiynJGkdp/u4Is+j64A==", null, false, "28d6cb4a-ad32-47c5-9183-f80b7b474741", false, "Zenos" },
                    { "3", 0, "d10448c6-3013-42e1-a109-54f5502d9dc2", "adem@example.com", false, "Adem", "Tounsi", false, null, "ADEM@EXAMPLE.COM", null, "AQAAAAIAAYagAAAAEEMZv8A6z5ahQkkb+qNxuhzydBP8pHmn5l+lD/au7VfyG25pF2bahihd8/+/mp4+1w==", null, false, "f5849c9d-43ab-43c0-a9ae-7363fecf6ac8", false, "EDP" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

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
    }
}

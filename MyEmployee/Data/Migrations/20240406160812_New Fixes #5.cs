using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyEmployee.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFixes5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "8f1adf6d-6820-4e20-bac5-069203ce8bb4", "Aziz@example.com", true, "Aziz", "Hmidi", false, null, "aziz@example.com", null, "AQAAAAIAAYagAAAAEJGSGrJ4rC6VOcDEjX6hLzWPM8LvaiuPEPc/lBOe9ZB6chBgna3GevEWAdLA+jMxlg==", null, false, "953b6fa6-bb6b-4d22-9347-a62b4e4349c0", false, "Paranoid" },
                    { "2", 0, "9066215c-0b5c-4627-a3c7-3d707a001027", "Arslen@example.com", true, "Arslen", "Chabaanie", false, null, "arslen@example.com", null, "AQAAAAIAAYagAAAAEK08qn82q6aR6rAsUfjsj/ZoOOTGHvYerVPh5pcHlRNHmxTzu2gvOMAaGgMg7En9Ww==", null, false, "69296697-2a15-45d8-944d-9af4e38dd48d", false, "Zenos" },
                    { "3", 0, "8c37db7d-f434-4803-ad43-454f8cc22d76", "adem@example.com", true, "Adem", "Tounsi", false, null, "adem@example.com", null, "AQAAAAIAAYagAAAAEDX3pgUweCJf7eO2oMkg8MOdp4LabaaQAkxScWPeDR/57pbKT2iYqFjZMKtSE8xuuA==", null, false, "3753ae6d-b4e3-4efd-a0da-df18aa75c577", false, "EDP" }
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
    }
}

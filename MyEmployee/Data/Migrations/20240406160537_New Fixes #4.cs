using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEmployee.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFixes4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f1adf6d-6820-4e20-bac5-069203ce8bb4", "Aziz@example.com", true, false, "aziz@example.com", "AQAAAAIAAYagAAAAEJGSGrJ4rC6VOcDEjX6hLzWPM8LvaiuPEPc/lBOe9ZB6chBgna3GevEWAdLA+jMxlg==", "953b6fa6-bb6b-4d22-9347-a62b4e4349c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9066215c-0b5c-4627-a3c7-3d707a001027", "Arslen@example.com", true, false, "arslen@example.com", "AQAAAAIAAYagAAAAEK08qn82q6aR6rAsUfjsj/ZoOOTGHvYerVPh5pcHlRNHmxTzu2gvOMAaGgMg7En9Ww==", "69296697-2a15-45d8-944d-9af4e38dd48d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c37db7d-f434-4803-ad43-454f8cc22d76", true, false, "adem@example.com", "AQAAAAIAAYagAAAAEDX3pgUweCJf7eO2oMkg8MOdp4LabaaQAkxScWPeDR/57pbKT2iYqFjZMKtSE8xuuA==", "3753ae6d-b4e3-4efd-a0da-df18aa75c577" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ce87a33-d903-4924-adc8-346f5ad57c37", "aziz@example.com", false, true, "AZIZ@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEXlPzpoLBXqwwkIFb3tjteuDAq6JKPdVn6yxnumN54McVbm5HXo5AEa2SxFZUlCJg==", "37de321a-8fbe-4fa7-af74-060822d15292" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5268b4c-59bc-453b-a66d-c348c765a8a1", "arslen@example.com", false, true, "ARSLEN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEEZlCFNW+3+Pgf+mlii7Y2G9kFN8/54NUCXslven30aw7EWSqK8n34alJYiVg6qGw==", "b3a4860b-690c-4978-8463-1255d87f5c22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a566505f-3985-4cb3-aa3b-d7e18760f643", false, true, "ADEM@EXAMPLE.COM", "AQAAAAIAAYagAAAAENfFYiMOnZTXBUIrj31OHaUJFXQw3NTXBno1LwyMUFFqiv4K/qzHTA7fKdX3fLC50Q==", "c3433e77-9651-48b5-8057-9d014a099be1" });
        }
    }
}

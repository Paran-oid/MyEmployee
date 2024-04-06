using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEmployee.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFixes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ce87a33-d903-4924-adc8-346f5ad57c37", true, "AQAAAAIAAYagAAAAEEXlPzpoLBXqwwkIFb3tjteuDAq6JKPdVn6yxnumN54McVbm5HXo5AEa2SxFZUlCJg==", "37de321a-8fbe-4fa7-af74-060822d15292" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5268b4c-59bc-453b-a66d-c348c765a8a1", true, "AQAAAAIAAYagAAAAEEEZlCFNW+3+Pgf+mlii7Y2G9kFN8/54NUCXslven30aw7EWSqK8n34alJYiVg6qGw==", "b3a4860b-690c-4978-8463-1255d87f5c22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a566505f-3985-4cb3-aa3b-d7e18760f643", true, "AQAAAAIAAYagAAAAENfFYiMOnZTXBUIrj31OHaUJFXQw3NTXBno1LwyMUFFqiv4K/qzHTA7fKdX3fLC50Q==", "c3433e77-9651-48b5-8057-9d014a099be1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d797335-effd-4baf-8c5a-1be201256d6d", false, "AQAAAAIAAYagAAAAEJVg+CdaBG/DYTLulGX3S0CK5GyKTyP5Ht3mdW076sr+3OifwaqqOE/DJqfguWLusg==", "058c0eee-8f43-425a-8e7b-eaf96925dfa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28491d91-686c-42c5-a6da-03e7a995c263", false, "AQAAAAIAAYagAAAAEOE3jXh45b9Sguv1bzy9mHm72gwAXsPV0WuTSwhiLoSH3LxUiynJGkdp/u4Is+j64A==", "28d6cb4a-ad32-47c5-9183-f80b7b474741" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d10448c6-3013-42e1-a109-54f5502d9dc2", false, "AQAAAAIAAYagAAAAEEMZv8A6z5ahQkkb+qNxuhzydBP8pHmn5l+lD/au7VfyG25pF2bahihd8/+/mp4+1w==", "f5849c9d-43ab-43c0-a9ae-7363fecf6ac8" });
        }
    }
}

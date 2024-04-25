using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEmployee.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFix4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeHistory_EmployeeId",
                table: "EmployeeHistory");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHistory_EmployeeId",
                table: "EmployeeHistory",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeHistory_EmployeeId",
                table: "EmployeeHistory");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHistory_EmployeeId",
                table: "EmployeeHistory",
                column: "EmployeeId",
                unique: true);
        }
    }
}

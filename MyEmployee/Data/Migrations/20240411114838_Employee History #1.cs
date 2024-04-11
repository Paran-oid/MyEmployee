using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEmployee.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeHistory1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeHistory_Employees_EmployeeId1",
                table: "EmployeeHistory");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeHistory_EmployeeId1",
                table: "EmployeeHistory");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "EmployeeHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "EmployeeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHistory_EmployeeId1",
                table: "EmployeeHistory",
                column: "EmployeeId1",
                unique: true,
                filter: "[EmployeeId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeHistory_Employees_EmployeeId1",
                table: "EmployeeHistory",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}

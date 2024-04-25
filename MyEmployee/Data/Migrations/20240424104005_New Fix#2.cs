using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEmployee.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "EmployeeHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "EmployeeHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

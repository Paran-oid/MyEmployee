using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEmployee.Data.Migrations
{
    /// <inheritdoc />
    public partial class newfeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "Employees",
                newName: "ProfilePicturePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePicturePath",
                table: "Employees",
                newName: "ProfilePicture");
        }
    }
}

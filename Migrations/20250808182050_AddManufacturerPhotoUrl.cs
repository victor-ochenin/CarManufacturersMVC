using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufacturersMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddManufacturerPhotoUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Manufacturers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Manufacturers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufacturersMVC.Migrations
{
    /// <inheritdoc />
    public partial class SeedManufacturerPhotoUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Manufacturers SET PhotoUrl = 'images/photo_manufacturers/rayfield.jpg' WHERE Name = 'Rayfield' AND PhotoUrl IS NULL;");
            migrationBuilder.Sql("UPDATE Manufacturers SET PhotoUrl = 'images/photo_manufacturers/quadra.jpg' WHERE Name = 'Quadra' AND PhotoUrl IS NULL;");
            migrationBuilder.Sql("UPDATE Manufacturers SET PhotoUrl = 'images/photo_manufacturers/mizutani.jpg' WHERE Name = 'Mizutani' AND PhotoUrl IS NULL;");
            migrationBuilder.Sql("UPDATE Manufacturers SET PhotoUrl = 'images/photo_manufacturers/archer.jpg' WHERE Name = 'Archer' AND PhotoUrl IS NULL;");
            migrationBuilder.Sql("UPDATE Manufacturers SET PhotoUrl = 'images/photo_manufacturers/villefort.jpg' WHERE Name = 'Villefort' AND PhotoUrl IS NULL;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Manufacturers SET PhotoUrl = NULL WHERE Name IN ('Rayfield','Quadra','Mizutani','Archer','Villefort')");
        }
    }
}

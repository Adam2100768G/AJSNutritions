using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AJSNutritions.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_calories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Dishes");
        }
    }
}

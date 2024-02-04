using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AJSNutritions.Server.Migrations
{
    /// <inheritdoc />
    public partial class dish_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodLoggedItems");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "DishType",
                table: "Dishes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DishType",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodLoggedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodLogId = table.Column<int>(type: "int", nullable: false),
                    DishQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodLoggedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodLoggedItems_FoodLogs_FoodLogId",
                        column: x => x.FoodLogId,
                        principalTable: "FoodLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodLoggedItems_FoodLogId",
                table: "FoodLoggedItems",
                column: "FoodLogId");
        }
    }
}

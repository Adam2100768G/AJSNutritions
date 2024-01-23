using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AJSNutritions.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Food_Log_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "FoodLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodLoggedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishQuantity = table.Column<int>(type: "int", nullable: false),
                    FoodLogId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_FoodLogs_UserId",
                table: "FoodLogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodLoggedItems");

            migrationBuilder.DropTable(
                name: "FoodLogs");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AJSNutritions.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodLogs_AspNetUsers_ApplicationUserId",
                table: "FoodLogs");

            migrationBuilder.DropIndex(
                name: "IX_FoodLogs_ApplicationUserId",
                table: "FoodLogs");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "FoodLogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FoodLogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodLogs_UserId",
                table: "FoodLogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodLogs_AspNetUsers_UserId",
                table: "FoodLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodLogs_AspNetUsers_UserId",
                table: "FoodLogs");

            migrationBuilder.DropIndex(
                name: "IX_FoodLogs_UserId",
                table: "FoodLogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FoodLogs");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "FoodLogs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_FoodLogs_ApplicationUserId",
                table: "FoodLogs",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodLogs_AspNetUsers_ApplicationUserId",
                table: "FoodLogs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

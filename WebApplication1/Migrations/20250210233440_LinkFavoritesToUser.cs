using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class LinkFavoritesToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_favorites_UserId",
                table: "favorites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_users_UserId",
                table: "favorites",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favorites_users_UserId",
                table: "favorites");

            migrationBuilder.DropIndex(
                name: "IX_favorites_UserId",
                table: "favorites");
        }
    }
}

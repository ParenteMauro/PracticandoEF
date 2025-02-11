using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UserSeed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "EmailAddress", "Name", "Phone", "SurName" },
                values: new object[,]
                {
                    { 10, "user10@gmail.com", "user10", "Phone", "saddas" },
                    { 11, "user11@gmail.com", "user11", "Phone", "saddas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace pokemonTcgCollectionApi.Migrations
{
    public partial class CorrectBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserCard_UserId",
                table: "UserCard");

            migrationBuilder.CreateIndex(
                name: "IX_UserCard_UserId",
                table: "UserCard",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserCard_UserId",
                table: "UserCard");

            migrationBuilder.CreateIndex(
                name: "IX_UserCard_UserId",
                table: "UserCard",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5letters.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GameId",
                table: "Letters",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Letters_GameId",
                table: "Letters",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Letters_Games_GameId",
                table: "Letters",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letters_Games_GameId",
                table: "Letters");

            migrationBuilder.DropIndex(
                name: "IX_Letters_GameId",
                table: "Letters");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Letters");
        }
    }
}

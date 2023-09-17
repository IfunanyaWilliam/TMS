using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProjectIdFromAppTaskEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersTasks_Users_UserId",
                table: "UsersTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersTasks_Users_UserId",
                table: "UsersTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersTasks_Users_UserId",
                table: "UsersTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersTasks_Users_UserId",
                table: "UsersTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

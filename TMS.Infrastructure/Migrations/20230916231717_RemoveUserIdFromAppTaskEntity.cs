using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserIdFromAppTaskEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_Users_UserId",
                table: "AppTasks");

            migrationBuilder.DropIndex(
                name: "IX_AppTasks_UserId",
                table: "AppTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppTasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_UserId",
                table: "AppTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_Users_UserId",
                table: "AppTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

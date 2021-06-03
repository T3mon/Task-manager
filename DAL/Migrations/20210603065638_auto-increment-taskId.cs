using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class autoincrementtaskId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId",
                table: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserTasks",
                newName: "UserAsignedId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_UserId",
                table: "UserTasks",
                newName: "IX_UserTasks_UserAsignedId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserAsignedId",
                table: "UserTasks",
                column: "UserAsignedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserAsignedId",
                table: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "UserAsignedId",
                table: "UserTasks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_UserAsignedId",
                table: "UserTasks",
                newName: "IX_UserTasks_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId",
                table: "UserTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class updateuserTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserAsignedId",
                table: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "UserAsignedId",
                table: "UserTasks",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_UserAsignedId",
                table: "UserTasks",
                newName: "IX_UserTasks_UserId1");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId1",
                table: "UserTasks",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId1",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "UserTasks",
                newName: "UserAsignedId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_UserId1",
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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WoM_Labb2.Migrations
{
    public partial class derp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Tasks_TasksTaskID",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Users_UsersUserId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_TasksTaskID",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_UsersUserId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "TasksTaskID",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "Assignments");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TaskID",
                table: "Assignments",
                column: "TaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Tasks_TaskID",
                table: "Assignments",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Users_UserID",
                table: "Assignments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Tasks_TaskID",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Users_UserID",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_TaskID",
                table: "Assignments");

            migrationBuilder.AddColumn<int>(
                name: "TasksTaskID",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TasksTaskID",
                table: "Assignments",
                column: "TasksTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_UsersUserId",
                table: "Assignments",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Tasks_TasksTaskID",
                table: "Assignments",
                column: "TasksTaskID",
                principalTable: "Tasks",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Users_UsersUserId",
                table: "Assignments",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

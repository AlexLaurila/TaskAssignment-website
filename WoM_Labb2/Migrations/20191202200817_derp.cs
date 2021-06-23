using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WoM_Labb2.Migrations
{
    public partial class derp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginDateTime = table.Column<DateTime>(nullable: false),
                    DeadlineDateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Requirements = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    TasksTaskID = table.Column<int>(nullable: true),
                    UsersUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => new { x.UserID, x.TaskID });
                    table.ForeignKey(
                        name: "FK_Assignments_Tasks_TasksTaskID",
                        column: x => x.TasksTaskID,
                        principalTable: "Tasks",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TasksTaskID",
                table: "Assignments",
                column: "TasksTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_UsersUserId",
                table: "Assignments",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

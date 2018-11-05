using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoCore.Business.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Reminder_ReminderId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_ReminderId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "ReminderId",
                table: "Task");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Reminder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_TaskId",
                table: "Reminder",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_Task_TaskId",
                table: "Reminder",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_Task_TaskId",
                table: "Reminder");

            migrationBuilder.DropIndex(
                name: "IX_Reminder_TaskId",
                table: "Reminder");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Reminder");

            migrationBuilder.AddColumn<int>(
                name: "ReminderId",
                table: "Task",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Task_ReminderId",
                table: "Task",
                column: "ReminderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Reminder_ReminderId",
                table: "Task",
                column: "ReminderId",
                principalTable: "Reminder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

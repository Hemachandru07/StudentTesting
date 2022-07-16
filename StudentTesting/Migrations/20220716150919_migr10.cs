using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTesting.Migrations
{
    public partial class migr10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_marks_StudentId",
                table: "marks",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_marks_studenttbls_StudentId",
                table: "marks",
                column: "StudentId",
                principalTable: "studenttbls",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marks_studenttbls_StudentId",
                table: "marks");

            migrationBuilder.DropIndex(
                name: "IX_marks_StudentId",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "marks");
        }
    }
}

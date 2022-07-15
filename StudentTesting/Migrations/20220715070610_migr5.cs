using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTesting.Migrations
{
    public partial class migr5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "markstables",
                columns: table => new
                {
                    MarksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject1 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Subject2 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Subject3 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Subject4 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Subject5 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Subject6 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_markstables", x => x.MarksId);
                    table.ForeignKey(
                        name: "FK_markstables_studenttbls_StudentId",
                        column: x => x.StudentId,
                        principalTable: "studenttbls",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_markstables_StudentId",
                table: "markstables",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "markstables");
        }
    }
}

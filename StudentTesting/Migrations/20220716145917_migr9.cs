using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTesting.Migrations
{
    public partial class migr9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marks",
                columns: table => new
                {
                    MarksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject1 = table.Column<int>(type: "int", nullable: false),
                    Subject2 = table.Column<int>(type: "int", nullable: false),
                    Subject3 = table.Column<int>(type: "int", nullable: false),
                    Subject4 = table.Column<int>(type: "int", nullable: false),
                    Subject5 = table.Column<int>(type: "int", nullable: false),
                    Subject6 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marks", x => x.MarksId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "marks");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTesting.Migrations
{
    public partial class migr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "teachertbls",
                newName: "Password");

            migrationBuilder.AlterColumn<long>(
                name: "Mobile_No",
                table: "studenttbls",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "teachertbls",
                newName: "PassWord");

            migrationBuilder.AlterColumn<int>(
                name: "Mobile_No",
                table: "studenttbls",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}

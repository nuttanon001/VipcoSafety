using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class updateConfine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpNameThai",
                table: "ConfinedHasEmpWorks",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpNameThai",
                table: "ConfinedHasEmpHelps",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpNameThai",
                table: "ConfinedHasEmpWorks");

            migrationBuilder.DropColumn(
                name: "EmpNameThai",
                table: "ConfinedHasEmpHelps");
        }
    }
}

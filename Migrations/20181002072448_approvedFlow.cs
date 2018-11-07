using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class approvedFlow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApprovedByNameThai",
                table: "ApprovedFlowMasters",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByMail",
                table: "ApprovedFlowMasters",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedByMail",
                table: "ApprovedFlowMasters");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedByNameThai",
                table: "ApprovedFlowMasters",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}

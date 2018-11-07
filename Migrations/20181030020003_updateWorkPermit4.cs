using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class updateWorkPermit4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Line7ShacklesSize",
                table: "Lifting1WorkPermit",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Line6BurlapSize",
                table: "Lifting1WorkPermit",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Line5ChainSize",
                table: "Lifting1WorkPermit",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Line4SlingSize",
                table: "Lifting1WorkPermit",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Line2OverHeadCrancSize",
                table: "Lifting1WorkPermit",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Line2MobileCrancSize",
                table: "Lifting1WorkPermit",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Line7ShacklesSize",
                table: "Lifting1WorkPermit",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Line6BurlapSize",
                table: "Lifting1WorkPermit",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Line5ChainSize",
                table: "Lifting1WorkPermit",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Line4SlingSize",
                table: "Lifting1WorkPermit",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Line2OverHeadCrancSize",
                table: "Lifting1WorkPermit",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Line2MobileCrancSize",
                table: "Lifting1WorkPermit",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class updateWorkPermit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSendMail",
                table: "RayWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSendMail",
                table: "PressureWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSendMail",
                table: "MachineAtWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSendMail",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSendMail",
                table: "HotWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSendMail",
                table: "HeightWorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSendMail",
                table: "ElectricalWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSendMail",
                table: "ConfinedSpaceWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSendMail",
                table: "ColdWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSendMail",
                table: "ChemicalWorkPermits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSendMail",
                table: "RayWorkPermits");

            migrationBuilder.DropColumn(
                name: "IsSendMail",
                table: "PressureWorkPermits");

            migrationBuilder.DropColumn(
                name: "IsSendMail",
                table: "MachineAtWorkPermits");

            migrationBuilder.DropColumn(
                name: "IsSendMail",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "IsSendMail",
                table: "HotWorkPermits");

            migrationBuilder.DropColumn(
                name: "IsSendMail",
                table: "HeightWorkPermit");

            migrationBuilder.DropColumn(
                name: "IsSendMail",
                table: "ElectricalWorkPermits");

            migrationBuilder.DropColumn(
                name: "IsSendMail",
                table: "ConfinedSpaceWorkPermits");

            migrationBuilder.DropColumn(
                name: "IsSendMail",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "IsSendMail",
                table: "ChemicalWorkPermits");
        }
    }
}

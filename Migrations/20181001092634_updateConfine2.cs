using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class updateConfine2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameEng",
                table: "RayHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameThai",
                table: "RayHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameEng",
                table: "RayHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameThai",
                table: "RayHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameEng",
                table: "PressureHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameThai",
                table: "PressureHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameEng",
                table: "PressureHasCheckList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameThai",
                table: "PressureHasCheckList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameEng",
                table: "MachineHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameThai",
                table: "MachineHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameEng",
                table: "MachineHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameThai",
                table: "MachineHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameEng",
                table: "HotHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameThai",
                table: "HotHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameEng",
                table: "HotHasCheckList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameThai",
                table: "HotHasCheckList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameEng",
                table: "HeightHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameThai",
                table: "HeightHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameEng",
                table: "HeightHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameThai",
                table: "HeightHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameEng",
                table: "ElectricalHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameThai",
                table: "ElectricalHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameEng",
                table: "ElectricalHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameThai",
                table: "ElectricalHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameEng",
                table: "ConfinedHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameThai",
                table: "ConfinedHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameEng",
                table: "ConfinedHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameThai",
                table: "ConfinedHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameEng",
                table: "ColdHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameThai",
                table: "ColdHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameEng",
                table: "ColdHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameThai",
                table: "ColdHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameEng",
                table: "ChemicalHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyEquipmentNameThai",
                table: "ChemicalHasEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameEng",
                table: "ChemicalHasCheckLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckListNameThai",
                table: "ChemicalHasCheckLists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameEng",
                table: "RayHasEquips");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameThai",
                table: "RayHasEquips");

            migrationBuilder.DropColumn(
                name: "CheckListNameEng",
                table: "RayHasCheckLists");

            migrationBuilder.DropColumn(
                name: "CheckListNameThai",
                table: "RayHasCheckLists");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameEng",
                table: "PressureHasEquips");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameThai",
                table: "PressureHasEquips");

            migrationBuilder.DropColumn(
                name: "CheckListNameEng",
                table: "PressureHasCheckList");

            migrationBuilder.DropColumn(
                name: "CheckListNameThai",
                table: "PressureHasCheckList");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameEng",
                table: "MachineHasEquips");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameThai",
                table: "MachineHasEquips");

            migrationBuilder.DropColumn(
                name: "CheckListNameEng",
                table: "MachineHasCheckLists");

            migrationBuilder.DropColumn(
                name: "CheckListNameThai",
                table: "MachineHasCheckLists");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameEng",
                table: "HotHasEquips");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameThai",
                table: "HotHasEquips");

            migrationBuilder.DropColumn(
                name: "CheckListNameEng",
                table: "HotHasCheckList");

            migrationBuilder.DropColumn(
                name: "CheckListNameThai",
                table: "HotHasCheckList");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameEng",
                table: "HeightHasEquips");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameThai",
                table: "HeightHasEquips");

            migrationBuilder.DropColumn(
                name: "CheckListNameEng",
                table: "HeightHasCheckLists");

            migrationBuilder.DropColumn(
                name: "CheckListNameThai",
                table: "HeightHasCheckLists");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameEng",
                table: "ElectricalHasEquips");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameThai",
                table: "ElectricalHasEquips");

            migrationBuilder.DropColumn(
                name: "CheckListNameEng",
                table: "ElectricalHasCheckLists");

            migrationBuilder.DropColumn(
                name: "CheckListNameThai",
                table: "ElectricalHasCheckLists");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameEng",
                table: "ConfinedHasEquips");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameThai",
                table: "ConfinedHasEquips");

            migrationBuilder.DropColumn(
                name: "CheckListNameEng",
                table: "ConfinedHasCheckLists");

            migrationBuilder.DropColumn(
                name: "CheckListNameThai",
                table: "ConfinedHasCheckLists");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameEng",
                table: "ColdHasEquips");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameThai",
                table: "ColdHasEquips");

            migrationBuilder.DropColumn(
                name: "CheckListNameEng",
                table: "ColdHasCheckLists");

            migrationBuilder.DropColumn(
                name: "CheckListNameThai",
                table: "ColdHasCheckLists");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameEng",
                table: "ChemicalHasEquips");

            migrationBuilder.DropColumn(
                name: "SafetyEquipmentNameThai",
                table: "ChemicalHasEquips");

            migrationBuilder.DropColumn(
                name: "CheckListNameEng",
                table: "ChemicalHasCheckLists");

            migrationBuilder.DropColumn(
                name: "CheckListNameThai",
                table: "ChemicalHasCheckLists");
        }
    }
}

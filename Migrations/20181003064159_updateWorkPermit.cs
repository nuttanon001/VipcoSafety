using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class updateWorkPermit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckListLine1",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "CheckListLine10",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "CheckListLine2",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "CheckListLine3",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "CheckListLine4",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "CheckListLine5",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "CheckListLine6",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "CheckListLine7",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "CheckListLine8",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "CheckListLine9",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "EquipLine1",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "EquipLine10",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "EquipLine2",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "EquipLine3",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "EquipLine4",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "EquipLine5",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "LiftMode1",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "LiftMode2",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "LiftMode3",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "LiftMode4",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "LiftMode5",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "LiftMode6",
                table: "Lifting1WorkPermit");

            migrationBuilder.RenameColumn(
                name: "EquipLine9",
                table: "Lifting1WorkPermit",
                newName: "RepayMail");

            migrationBuilder.RenameColumn(
                name: "EquipLine8",
                table: "Lifting1WorkPermit",
                newName: "Other");

            migrationBuilder.RenameColumn(
                name: "EquipLine7",
                table: "Lifting1WorkPermit",
                newName: "Line1Comment");

            migrationBuilder.RenameColumn(
                name: "EquipLine6",
                table: "Lifting1WorkPermit",
                newName: "ComplateByName");

            migrationBuilder.AddColumn<string>(
                name: "RepayMail",
                table: "RayWorkPermits",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepayMail",
                table: "PressureWorkPermits",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepayMail",
                table: "MachineAtWorkPermits",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplateBy",
                table: "Lifting1WorkPermit",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ComplateDate",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplateTimeString",
                table: "Lifting1WorkPermit",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupWorkPermitId",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line10GG",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line10Ton",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line1TotalWeight",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Line2MobileCrancEa",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line2MobileCrancSize",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Line2OverHeadCrancEa",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line2OverHeadCrancSize",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line3HeightWork",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line3LengthWork",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line3WidthWork",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line4SlingLength",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line4SlingSize",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line4SlingTotal",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line5ChainLength",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line5ChainSize",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line5ChainTotal",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line6BurlapSize",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line6BurlapTotal",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line6burlapLength",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line7ShacklesSize",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line7ShacklesTotal",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line8LiftCarry",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line8LiftDegree",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line8TypeLiftTotal",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line9ChainHoistSize",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line9CummalongSize",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line9LiftingBeamLength",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line9LiftingBeamWeigth",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequireByEmpCode",
                table: "Lifting1WorkPermit",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequireByEmpName",
                table: "Lifting1WorkPermit",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepayMail",
                table: "HotWorkPermits",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepayMail",
                table: "HeightWorkPermit",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepayMail",
                table: "ElectricalWorkPermits",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepayMail",
                table: "ConfinedSpaceWorkPermits",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepayMail",
                table: "ColdWorkPermits",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepayMail",
                table: "ChemicalWorkPermits",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LiftingHasCheckList",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    CheckListId = table.Column<int>(nullable: true),
                    CheckListNameThai = table.Column<string>(maxLength: 200, nullable: true),
                    CheckListNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    LiftingHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lifting1WorkPermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingHasCheckList", x => x.LiftingHasCheckListId);
                    table.ForeignKey(
                        name: "FK_LiftingHasCheckList_Lifting1WorkPermit_Lifting1WorkPermitId",
                        column: x => x.Lifting1WorkPermitId,
                        principalTable: "Lifting1WorkPermit",
                        principalColumn: "Lifting1WorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LiftingHasEquip",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    SafetyEquipmentNameThai = table.Column<string>(maxLength: 200, nullable: true),
                    SafetyEquipmentNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    LiftingHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lifting1WorkPermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingHasEquip", x => x.LiftingHasEquipId);
                    table.ForeignKey(
                        name: "FK_LiftingHasEquip_Lifting1WorkPermit_Lifting1WorkPermitId",
                        column: x => x.Lifting1WorkPermitId,
                        principalTable: "Lifting1WorkPermit",
                        principalColumn: "Lifting1WorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lifting1WorkPermit_GroupWorkPermitId",
                table: "Lifting1WorkPermit",
                column: "GroupWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingHasCheckList_Lifting1WorkPermitId",
                table: "LiftingHasCheckList",
                column: "Lifting1WorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingHasEquip_Lifting1WorkPermitId",
                table: "LiftingHasEquip",
                column: "Lifting1WorkPermitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lifting1WorkPermit_GroupWorkPermits_GroupWorkPermitId",
                table: "Lifting1WorkPermit",
                column: "GroupWorkPermitId",
                principalTable: "GroupWorkPermits",
                principalColumn: "GroupWorkPermitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lifting1WorkPermit_GroupWorkPermits_GroupWorkPermitId",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropTable(
                name: "LiftingHasCheckList");

            migrationBuilder.DropTable(
                name: "LiftingHasEquip");

            migrationBuilder.DropIndex(
                name: "IX_Lifting1WorkPermit_GroupWorkPermitId",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "RepayMail",
                table: "RayWorkPermits");

            migrationBuilder.DropColumn(
                name: "RepayMail",
                table: "PressureWorkPermits");

            migrationBuilder.DropColumn(
                name: "RepayMail",
                table: "MachineAtWorkPermits");

            migrationBuilder.DropColumn(
                name: "ComplateBy",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "ComplateDate",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "ComplateTimeString",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "GroupWorkPermitId",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line10GG",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line10Ton",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line1TotalWeight",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line2MobileCrancEa",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line2MobileCrancSize",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line2OverHeadCrancEa",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line2OverHeadCrancSize",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line3HeightWork",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line3LengthWork",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line3WidthWork",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line4SlingLength",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line4SlingSize",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line4SlingTotal",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line5ChainLength",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line5ChainSize",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line5ChainTotal",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line6BurlapSize",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line6BurlapTotal",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line6burlapLength",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line7ShacklesSize",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line7ShacklesTotal",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line8LiftCarry",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line8LiftDegree",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line8TypeLiftTotal",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line9ChainHoistSize",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line9CummalongSize",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line9LiftingBeamLength",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "Line9LiftingBeamWeigth",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "RequireByEmpCode",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "RequireByEmpName",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "RepayMail",
                table: "HotWorkPermits");

            migrationBuilder.DropColumn(
                name: "RepayMail",
                table: "HeightWorkPermit");

            migrationBuilder.DropColumn(
                name: "RepayMail",
                table: "ElectricalWorkPermits");

            migrationBuilder.DropColumn(
                name: "RepayMail",
                table: "ConfinedSpaceWorkPermits");

            migrationBuilder.DropColumn(
                name: "RepayMail",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "RepayMail",
                table: "ChemicalWorkPermits");

            migrationBuilder.RenameColumn(
                name: "RepayMail",
                table: "Lifting1WorkPermit",
                newName: "EquipLine9");

            migrationBuilder.RenameColumn(
                name: "Other",
                table: "Lifting1WorkPermit",
                newName: "EquipLine8");

            migrationBuilder.RenameColumn(
                name: "Line1Comment",
                table: "Lifting1WorkPermit",
                newName: "EquipLine7");

            migrationBuilder.RenameColumn(
                name: "ComplateByName",
                table: "Lifting1WorkPermit",
                newName: "EquipLine6");

            migrationBuilder.AddColumn<bool>(
                name: "CheckListLine1",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckListLine10",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckListLine2",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckListLine3",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckListLine4",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckListLine5",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckListLine6",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckListLine7",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckListLine8",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckListLine9",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EquipLine1",
                table: "Lifting1WorkPermit",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquipLine10",
                table: "Lifting1WorkPermit",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquipLine2",
                table: "Lifting1WorkPermit",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquipLine3",
                table: "Lifting1WorkPermit",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquipLine4",
                table: "Lifting1WorkPermit",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquipLine5",
                table: "Lifting1WorkPermit",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LiftMode1",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LiftMode2",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LiftMode3",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LiftMode4",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LiftMode5",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LiftMode6",
                table: "Lifting1WorkPermit",
                nullable: false,
                defaultValue: false);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class removeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChemicalHasCheckLists");

            migrationBuilder.DropTable(
                name: "ChemicalHasEquips");

            migrationBuilder.DropTable(
                name: "ColdHasCheckLists");

            migrationBuilder.DropTable(
                name: "ColdHasEquips");

            migrationBuilder.DropTable(
                name: "ElectricalHasCheckLists");

            migrationBuilder.DropTable(
                name: "ElectricalHasEquips");

            migrationBuilder.DropTable(
                name: "HeightHasCheckLists");

            migrationBuilder.DropTable(
                name: "HeightHasEquips");

            migrationBuilder.DropTable(
                name: "HotHasCheckList");

            migrationBuilder.DropTable(
                name: "HotHasEquips");

            migrationBuilder.DropTable(
                name: "MachineHasCheckLists");

            migrationBuilder.DropTable(
                name: "MachineHasEquips");

            migrationBuilder.DropTable(
                name: "PressureHasCheckList");

            migrationBuilder.DropTable(
                name: "PressureHasEquips");

            migrationBuilder.DropTable(
                name: "RayHasCheckLists");

            migrationBuilder.DropTable(
                name: "RayHasEquips");

            migrationBuilder.DropTable(
                name: "ChemicalWorkPermits");

            migrationBuilder.DropTable(
                name: "ColdWorkPermits");

            migrationBuilder.DropTable(
                name: "ElectricalWorkPermits");

            migrationBuilder.DropTable(
                name: "HeightWorkPermit");

            migrationBuilder.DropTable(
                name: "HotWorkPermits");

            migrationBuilder.DropTable(
                name: "MachineAtWorkPermits");

            migrationBuilder.DropTable(
                name: "PressureWorkPermits");

            migrationBuilder.DropTable(
                name: "RayWorkPermits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChemicalWorkPermits",
                columns: table => new
                {
                    ChemicalWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: true),
                    InsulationWork = table.Column<bool>(nullable: true),
                    IsSendMail = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    PaintAndBlastWork = table.Column<bool>(nullable: true),
                    PassivationWokr = table.Column<bool>(nullable: true),
                    RepayMail = table.Column<string>(maxLength: 200, nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalWorkPermits", x => x.ChemicalWorkPermitId);
                    table.ForeignKey(
                        name: "FK_ChemicalWorkPermits_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColdWorkPermits",
                columns: table => new
                {
                    ColdWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    ConstructionWork = table.Column<bool>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: true),
                    IsSendMail = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    RepayMail = table.Column<string>(maxLength: 200, nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColdWorkPermits", x => x.ColdWorkPermitId);
                    table.ForeignKey(
                        name: "FK_ColdWorkPermits_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectricalWorkPermits",
                columns: table => new
                {
                    ElectricalPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: true),
                    InstallWork = table.Column<bool>(nullable: true),
                    IsSendMail = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    RepairWork = table.Column<bool>(nullable: true),
                    RepayMail = table.Column<string>(maxLength: 200, nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: true),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalWorkPermits", x => x.ElectricalPermitId);
                    table.ForeignKey(
                        name: "FK_ElectricalWorkPermits_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeightWorkPermit",
                columns: table => new
                {
                    HeightWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: true),
                    InstallWork = table.Column<bool>(nullable: true),
                    IsSendMail = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    RepairWork = table.Column<bool>(nullable: true),
                    RepayMail = table.Column<string>(maxLength: 200, nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeightWorkPermit", x => x.HeightWorkPermitId);
                    table.ForeignKey(
                        name: "FK_HeightWorkPermit_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotWorkPermits",
                columns: table => new
                {
                    HotWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: true),
                    HotWork = table.Column<bool>(nullable: true),
                    IsSendMail = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    PostWeldWork = table.Column<bool>(nullable: true),
                    RepayMail = table.Column<string>(maxLength: 200, nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotWorkPermits", x => x.HotWorkPermitId);
                    table.ForeignKey(
                        name: "FK_HotWorkPermits_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachineAtWorkPermits",
                columns: table => new
                {
                    MachineAtWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    BendingMachine = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    FormingNachine = table.Column<bool>(nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: true),
                    HydraulicMachine = table.Column<bool>(nullable: true),
                    IsSendMail = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    MachineNo = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    RepayMail = table.Column<string>(maxLength: 200, nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAtWorkPermits", x => x.MachineAtWorkPermitId);
                    table.ForeignKey(
                        name: "FK_MachineAtWorkPermits_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PressureWorkPermits",
                columns: table => new
                {
                    PressureWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    AriLeakWork = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: true),
                    HydroWork = table.Column<bool>(nullable: true),
                    IsSendMail = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    NitrogenWork = table.Column<bool>(nullable: true),
                    RepayMail = table.Column<string>(maxLength: 200, nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressureWorkPermits", x => x.PressureWorkPermitId);
                    table.ForeignKey(
                        name: "FK_PressureWorkPermits_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RayWorkPermits",
                columns: table => new
                {
                    RayWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    ControlBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    GemmaRay = table.Column<bool>(nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: true),
                    IsSendMail = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    RayNo = table.Column<string>(maxLength: 200, nullable: true),
                    RayStrength = table.Column<string>(maxLength: 50, nullable: true),
                    RepayMail = table.Column<string>(maxLength: 200, nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SafetyLength = table.Column<double>(nullable: false),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    XRay = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RayWorkPermits", x => x.RayWorkPermitId);
                    table.ForeignKey(
                        name: "FK_RayWorkPermits_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChemicalHasCheckLists",
                columns: table => new
                {
                    ChemicalHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckListId = table.Column<int>(nullable: true),
                    CheckListNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    CheckListNameThai = table.Column<string>(maxLength: 200, nullable: true),
                    ChemicalWorkPermitId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalHasCheckLists", x => x.ChemicalHasCheckListId);
                    table.ForeignKey(
                        name: "FK_ChemicalHasCheckLists_ChemicalWorkPermits_ChemicalWorkPermitId",
                        column: x => x.ChemicalWorkPermitId,
                        principalTable: "ChemicalWorkPermits",
                        principalColumn: "ChemicalWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChemicalHasEquips",
                columns: table => new
                {
                    ChemicalHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChemicalWorkPermitId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    SafetyEquipmentNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    SafetyEquipmentNameThai = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalHasEquips", x => x.ChemicalHasEquipId);
                    table.ForeignKey(
                        name: "FK_ChemicalHasEquips_ChemicalWorkPermits_ChemicalWorkPermitId",
                        column: x => x.ChemicalWorkPermitId,
                        principalTable: "ChemicalWorkPermits",
                        principalColumn: "ChemicalWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColdHasCheckLists",
                columns: table => new
                {
                    ColdHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckListId = table.Column<int>(nullable: true),
                    CheckListNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    CheckListNameThai = table.Column<string>(maxLength: 200, nullable: true),
                    ColdWorkPermitId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColdHasCheckLists", x => x.ColdHasCheckListId);
                    table.ForeignKey(
                        name: "FK_ColdHasCheckLists_ColdWorkPermits_ColdWorkPermitId",
                        column: x => x.ColdWorkPermitId,
                        principalTable: "ColdWorkPermits",
                        principalColumn: "ColdWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColdHasEquips",
                columns: table => new
                {
                    ColdHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColdWorkPermitId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    SafetyEquipmentNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    SafetyEquipmentNameThai = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColdHasEquips", x => x.ColdHasEquipId);
                    table.ForeignKey(
                        name: "FK_ColdHasEquips_ColdWorkPermits_ColdWorkPermitId",
                        column: x => x.ColdWorkPermitId,
                        principalTable: "ColdWorkPermits",
                        principalColumn: "ColdWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectricalHasCheckLists",
                columns: table => new
                {
                    ElectricalHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckListId = table.Column<int>(nullable: true),
                    CheckListNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    CheckListNameThai = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    ElectricalPermitId = table.Column<int>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalHasCheckLists", x => x.ElectricalHasCheckListId);
                    table.ForeignKey(
                        name: "FK_ElectricalHasCheckLists_ElectricalWorkPermits_ElectricalPermitId",
                        column: x => x.ElectricalPermitId,
                        principalTable: "ElectricalWorkPermits",
                        principalColumn: "ElectricalPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectricalHasEquips",
                columns: table => new
                {
                    ElectricalHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    ElectricalPermitId = table.Column<int>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    SafetyEquipmentNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    SafetyEquipmentNameThai = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalHasEquips", x => x.ElectricalHasEquipId);
                    table.ForeignKey(
                        name: "FK_ElectricalHasEquips_ElectricalWorkPermits_ElectricalPermitId",
                        column: x => x.ElectricalPermitId,
                        principalTable: "ElectricalWorkPermits",
                        principalColumn: "ElectricalPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeightHasCheckLists",
                columns: table => new
                {
                    HeightHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckListId = table.Column<int>(nullable: true),
                    CheckListNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    CheckListNameThai = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    HeightWorkPermitId = table.Column<int>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeightHasCheckLists", x => x.HeightHasCheckListId);
                    table.ForeignKey(
                        name: "FK_HeightHasCheckLists_HeightWorkPermit_HeightWorkPermitId",
                        column: x => x.HeightWorkPermitId,
                        principalTable: "HeightWorkPermit",
                        principalColumn: "HeightWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeightHasEquips",
                columns: table => new
                {
                    HeightHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    HeightWorkPermitId = table.Column<int>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    SafetyEquipmentNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    SafetyEquipmentNameThai = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeightHasEquips", x => x.HeightHasEquipId);
                    table.ForeignKey(
                        name: "FK_HeightHasEquips_HeightWorkPermit_HeightWorkPermitId",
                        column: x => x.HeightWorkPermitId,
                        principalTable: "HeightWorkPermit",
                        principalColumn: "HeightWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotHasCheckList",
                columns: table => new
                {
                    HotHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckListId = table.Column<int>(nullable: true),
                    CheckListNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    CheckListNameThai = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    HotWorkPermitId = table.Column<int>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotHasCheckList", x => x.HotHasCheckListId);
                    table.ForeignKey(
                        name: "FK_HotHasCheckList_HotWorkPermits_HotWorkPermitId",
                        column: x => x.HotWorkPermitId,
                        principalTable: "HotWorkPermits",
                        principalColumn: "HotWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotHasEquips",
                columns: table => new
                {
                    HasHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    HotWorkPermitId = table.Column<int>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    SafetyEquipmentNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    SafetyEquipmentNameThai = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotHasEquips", x => x.HasHasEquipId);
                    table.ForeignKey(
                        name: "FK_HotHasEquips_HotWorkPermits_HotWorkPermitId",
                        column: x => x.HotWorkPermitId,
                        principalTable: "HotWorkPermits",
                        principalColumn: "HotWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachineHasCheckLists",
                columns: table => new
                {
                    MachineHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckListId = table.Column<int>(nullable: true),
                    CheckListNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    CheckListNameThai = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    MachineAtWorkPermitId = table.Column<int>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineHasCheckLists", x => x.MachineHasCheckListId);
                    table.ForeignKey(
                        name: "FK_MachineHasCheckLists_MachineAtWorkPermits_MachineAtWorkPermitId",
                        column: x => x.MachineAtWorkPermitId,
                        principalTable: "MachineAtWorkPermits",
                        principalColumn: "MachineAtWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachineHasEquips",
                columns: table => new
                {
                    MachineHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    MachineAtWorkPermitId = table.Column<int>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    SafetyEquipmentNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    SafetyEquipmentNameThai = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineHasEquips", x => x.MachineHasEquipId);
                    table.ForeignKey(
                        name: "FK_MachineHasEquips_MachineAtWorkPermits_MachineAtWorkPermitId",
                        column: x => x.MachineAtWorkPermitId,
                        principalTable: "MachineAtWorkPermits",
                        principalColumn: "MachineAtWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PressureHasCheckList",
                columns: table => new
                {
                    PressureHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckListId = table.Column<int>(nullable: true),
                    CheckListNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    CheckListNameThai = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    PressureWorkPermitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressureHasCheckList", x => x.PressureHasCheckListId);
                    table.ForeignKey(
                        name: "FK_PressureHasCheckList_PressureWorkPermits_PressureWorkPermitId",
                        column: x => x.PressureWorkPermitId,
                        principalTable: "PressureWorkPermits",
                        principalColumn: "PressureWorkPermitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PressureHasEquips",
                columns: table => new
                {
                    PressureHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    PressureWorkPermitId = table.Column<int>(nullable: false),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    SafetyEquipmentNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    SafetyEquipmentNameThai = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressureHasEquips", x => x.PressureHasEquipId);
                    table.ForeignKey(
                        name: "FK_PressureHasEquips_PressureWorkPermits_PressureWorkPermitId",
                        column: x => x.PressureWorkPermitId,
                        principalTable: "PressureWorkPermits",
                        principalColumn: "PressureWorkPermitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RayHasCheckLists",
                columns: table => new
                {
                    RayHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckListId = table.Column<int>(nullable: true),
                    CheckListNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    CheckListNameThai = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    RayWorkPermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RayHasCheckLists", x => x.RayHasCheckListId);
                    table.ForeignKey(
                        name: "FK_RayHasCheckLists_RayWorkPermits_RayWorkPermitId",
                        column: x => x.RayWorkPermitId,
                        principalTable: "RayWorkPermits",
                        principalColumn: "RayWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RayHasEquips",
                columns: table => new
                {
                    RayHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    RayWorkPermitId = table.Column<int>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    SafetyEquipmentNameEng = table.Column<string>(maxLength: 200, nullable: true),
                    SafetyEquipmentNameThai = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RayHasEquips", x => x.RayHasEquipId);
                    table.ForeignKey(
                        name: "FK_RayHasEquips_RayWorkPermits_RayWorkPermitId",
                        column: x => x.RayWorkPermitId,
                        principalTable: "RayWorkPermits",
                        principalColumn: "RayWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalHasCheckLists_ChemicalWorkPermitId",
                table: "ChemicalHasCheckLists",
                column: "ChemicalWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalHasEquips_ChemicalWorkPermitId",
                table: "ChemicalHasEquips",
                column: "ChemicalWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalWorkPermits_GroupWorkPermitId",
                table: "ChemicalWorkPermits",
                column: "GroupWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ColdHasCheckLists_ColdWorkPermitId",
                table: "ColdHasCheckLists",
                column: "ColdWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ColdHasEquips_ColdWorkPermitId",
                table: "ColdHasEquips",
                column: "ColdWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ColdWorkPermits_GroupWorkPermitId",
                table: "ColdWorkPermits",
                column: "GroupWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalHasCheckLists_ElectricalPermitId",
                table: "ElectricalHasCheckLists",
                column: "ElectricalPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalHasEquips_ElectricalPermitId",
                table: "ElectricalHasEquips",
                column: "ElectricalPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalWorkPermits_GroupWorkPermitId",
                table: "ElectricalWorkPermits",
                column: "GroupWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_HeightHasCheckLists_HeightWorkPermitId",
                table: "HeightHasCheckLists",
                column: "HeightWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_HeightHasEquips_HeightWorkPermitId",
                table: "HeightHasEquips",
                column: "HeightWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_HeightWorkPermit_GroupWorkPermitId",
                table: "HeightWorkPermit",
                column: "GroupWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_HotHasCheckList_HotWorkPermitId",
                table: "HotHasCheckList",
                column: "HotWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_HotHasEquips_HotWorkPermitId",
                table: "HotHasEquips",
                column: "HotWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_HotWorkPermits_GroupWorkPermitId",
                table: "HotWorkPermits",
                column: "GroupWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAtWorkPermits_GroupWorkPermitId",
                table: "MachineAtWorkPermits",
                column: "GroupWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineHasCheckLists_MachineAtWorkPermitId",
                table: "MachineHasCheckLists",
                column: "MachineAtWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineHasEquips_MachineAtWorkPermitId",
                table: "MachineHasEquips",
                column: "MachineAtWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_PressureHasCheckList_PressureWorkPermitId",
                table: "PressureHasCheckList",
                column: "PressureWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_PressureHasEquips_PressureWorkPermitId",
                table: "PressureHasEquips",
                column: "PressureWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_PressureWorkPermits_GroupWorkPermitId",
                table: "PressureWorkPermits",
                column: "GroupWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_RayHasCheckLists_RayWorkPermitId",
                table: "RayHasCheckLists",
                column: "RayWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_RayHasEquips_RayWorkPermitId",
                table: "RayHasEquips",
                column: "RayWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_RayWorkPermits_GroupWorkPermitId",
                table: "RayWorkPermits",
                column: "GroupWorkPermitId");
        }
    }
}

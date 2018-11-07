using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovedFlowMasters",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ApprovedFlowMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedByEmp = table.Column<string>(maxLength: 50, nullable: true),
                    ApprovedByNameThai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedFlowMasters", x => x.ApprovedFlowMasterId);
                });

            migrationBuilder.CreateTable(
                name: "CheckLists",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameThai = table.Column<string>(maxLength: 250, nullable: true),
                    NameEng = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLists", x => x.CheckListId);
                });

            migrationBuilder.CreateTable(
                name: "GroupWorkPermits",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWorkPermits", x => x.GroupWorkPermitId);
                });

            migrationBuilder.CreateTable(
                name: "Lifting1WorkPermit",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Lifting1WorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OverTenTon = table.Column<bool>(nullable: true),
                    LengthOverTwelveMeter = table.Column<bool>(nullable: true),
                    WidthOverThreeMeter = table.Column<bool>(nullable: true),
                    TwoCraneLift = table.Column<bool>(nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    LiftDate = table.Column<DateTime>(nullable: true),
                    LiftDateTimeString = table.Column<string>(maxLength: 50, nullable: true),
                    JobNo = table.Column<string>(maxLength: 100, nullable: true),
                    WorkGroup = table.Column<string>(maxLength: 100, nullable: true),
                    Location = table.Column<string>(maxLength: 100, nullable: true),
                    SupervisorName = table.Column<string>(maxLength: 150, nullable: true),
                    EngineerName = table.Column<string>(maxLength: 150, nullable: true),
                    SignalName = table.Column<string>(maxLength: 150, nullable: true),
                    ControlCraneName = table.Column<string>(maxLength: 150, nullable: true),
                    ControlName = table.Column<string>(maxLength: 150, nullable: true),
                    ConnectName = table.Column<string>(maxLength: 150, nullable: true),
                    EquipLine1 = table.Column<string>(maxLength: 200, nullable: true),
                    EquipLine2 = table.Column<string>(maxLength: 200, nullable: true),
                    EquipLine3 = table.Column<string>(maxLength: 200, nullable: true),
                    EquipLine4 = table.Column<string>(maxLength: 200, nullable: true),
                    EquipLine5 = table.Column<string>(maxLength: 200, nullable: true),
                    EquipLine6 = table.Column<string>(maxLength: 200, nullable: true),
                    EquipLine7 = table.Column<string>(maxLength: 200, nullable: true),
                    EquipLine8 = table.Column<string>(maxLength: 200, nullable: true),
                    EquipLine9 = table.Column<string>(maxLength: 200, nullable: true),
                    EquipLine10 = table.Column<string>(maxLength: 200, nullable: true),
                    CheckListLine1 = table.Column<bool>(nullable: false),
                    CheckListLine2 = table.Column<bool>(nullable: false),
                    CheckListLine3 = table.Column<bool>(nullable: false),
                    CheckListLine4 = table.Column<bool>(nullable: false),
                    CheckListLine5 = table.Column<bool>(nullable: false),
                    CheckListLine6 = table.Column<bool>(nullable: false),
                    CheckListLine7 = table.Column<bool>(nullable: false),
                    CheckListLine8 = table.Column<bool>(nullable: false),
                    CheckListLine9 = table.Column<bool>(nullable: false),
                    CheckListLine10 = table.Column<bool>(nullable: false),
                    LiftMode1 = table.Column<bool>(nullable: false),
                    LiftMode2 = table.Column<bool>(nullable: false),
                    LiftMode3 = table.Column<bool>(nullable: false),
                    LiftMode4 = table.Column<bool>(nullable: false),
                    LiftMode5 = table.Column<bool>(nullable: false),
                    LiftMode6 = table.Column<bool>(nullable: false),
                    WeightPerLift = table.Column<double>(nullable: false),
                    Verify = table.Column<bool>(nullable: true),
                    VerifyTime = table.Column<string>(nullable: true),
                    VerifyFix = table.Column<string>(nullable: true),
                    Pass = table.Column<bool>(nullable: true),
                    PassTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lifting1WorkPermit", x => x.Lifting1WorkPermitId);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PremissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    LevelPermission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PremissionId);
                });

            migrationBuilder.CreateTable(
                name: "SafetyEquipments",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameThai = table.Column<string>(maxLength: 150, nullable: true),
                    NameEng = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyEquipments", x => x.SafetyEquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "ApprovedFlowDetails",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ApprovedFlowDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedFlowMasterId = table.Column<int>(nullable: true),
                    GroupMis = table.Column<string>(maxLength: 50, nullable: true),
                    GroupMisName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedFlowDetails", x => x.ApprovedFlowDetailId);
                    table.ForeignKey(
                        name: "FK_ApprovedFlowDetails_ApprovedFlowMasters_ApprovedFlowMasterId",
                        column: x => x.ApprovedFlowMasterId,
                        principalTable: "ApprovedFlowMasters",
                        principalColumn: "ApprovedFlowMasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChemicalWorkPermits",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    ChemicalWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PassivationWokr = table.Column<bool>(nullable: true),
                    InsulationWork = table.Column<bool>(nullable: true),
                    PaintAndBlastWork = table.Column<bool>(nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    GroupWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    ColdWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConstructionWork = table.Column<bool>(nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    GroupWorkPermitId = table.Column<int>(nullable: true)
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
                name: "ConfinedSpaceWorkPermits",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    ConfinedSpaceWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstallWork = table.Column<bool>(nullable: true),
                    RepairWork = table.Column<bool>(nullable: true),
                    HasHotPermit = table.Column<bool>(nullable: true),
                    HotPermitNo = table.Column<string>(maxLength: 50, nullable: true),
                    HotWorkGrinding = table.Column<bool>(nullable: true),
                    HotWorkCutting = table.Column<bool>(nullable: true),
                    HotWorkWelding = table.Column<bool>(nullable: true),
                    HotWorkOther = table.Column<bool>(nullable: true),
                    HotWorkOtherString = table.Column<string>(maxLength: 50, nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    GroupWorkPermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfinedSpaceWorkPermits", x => x.ConfinedSpaceWorkPermitId);
                    table.ForeignKey(
                        name: "FK_ConfinedSpaceWorkPermits_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectricalWorkPermits",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    ElectricalPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstallWork = table.Column<bool>(nullable: true),
                    RepairWork = table.Column<bool>(nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: true)
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
                name: "GroupPermitHasCheckLists",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    GroupHasCheckId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OptionValue = table.Column<bool>(nullable: true),
                    SequenceNo = table.Column<int>(nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: true),
                    CheckListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPermitHasCheckLists", x => x.GroupHasCheckId);
                    table.ForeignKey(
                        name: "FK_GroupPermitHasCheckLists_CheckLists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "CheckListId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupPermitHasCheckLists_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeightWorkPermit",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    HeightWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstallWork = table.Column<bool>(nullable: true),
                    RepairWork = table.Column<bool>(nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    GroupWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    HotWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostWeldWork = table.Column<bool>(nullable: true),
                    HotWork = table.Column<bool>(nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    GroupWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    MachineAtWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BendingMachine = table.Column<bool>(nullable: true),
                    HydraulicMachine = table.Column<bool>(nullable: true),
                    FormingNachine = table.Column<bool>(nullable: true),
                    MachineNo = table.Column<string>(maxLength: 200, nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    GroupWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    PressureWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NitrogenWork = table.Column<bool>(nullable: true),
                    AriLeakWork = table.Column<bool>(nullable: true),
                    HydroWork = table.Column<bool>(nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    GroupWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    RequireByEmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    RequireByEmpName = table.Column<string>(maxLength: 150, nullable: true),
                    SubContractor = table.Column<string>(maxLength: 250, nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 500, nullable: true),
                    WpStartDate = table.Column<DateTime>(nullable: true),
                    WpStartTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    WpEndDate = table.Column<DateTime>(nullable: true),
                    WpEndTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    TotalWorker = table.Column<int>(nullable: true),
                    SpecialTool = table.Column<string>(maxLength: 500, nullable: true),
                    WorkComplate = table.Column<bool>(nullable: true),
                    AreaClear = table.Column<bool>(nullable: true),
                    KeepOutClear = table.Column<bool>(nullable: true),
                    ComplateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ComplateByName = table.Column<string>(maxLength: 200, nullable: true),
                    ComplateDate = table.Column<DateTime>(nullable: true),
                    ComplateTimeString = table.Column<string>(maxLength: 10, nullable: true),
                    RayWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    XRay = table.Column<bool>(nullable: true),
                    GemmaRay = table.Column<bool>(nullable: true),
                    RayStrength = table.Column<string>(maxLength: 50, nullable: true),
                    SafetyLength = table.Column<double>(nullable: false),
                    ControlBy = table.Column<string>(maxLength: 200, nullable: true),
                    RayNo = table.Column<string>(maxLength: 200, nullable: true),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    GroupWorkPermitId = table.Column<int>(nullable: true)
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
                name: "TypeWorkPermits",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    TypeWorkPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameThai = table.Column<string>(maxLength: 150, nullable: true),
                    NameEng = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    SequenceNo = table.Column<int>(nullable: false),
                    StatusWorkPermit = table.Column<int>(nullable: false),
                    GroupWorkPermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeWorkPermits", x => x.TypeWorkPermitId);
                    table.ForeignKey(
                        name: "FK_TypeWorkPermits_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupPermitHasEquipments",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    GroupHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OptionValue = table.Column<bool>(nullable: true),
                    SequenceNo = table.Column<int>(nullable: true),
                    GroupWorkPermitId = table.Column<int>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPermitHasEquipments", x => x.GroupHasEquipId);
                    table.ForeignKey(
                        name: "FK_GroupPermitHasEquipments_GroupWorkPermits_GroupWorkPermitId",
                        column: x => x.GroupWorkPermitId,
                        principalTable: "GroupWorkPermits",
                        principalColumn: "GroupWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupPermitHasEquipments_SafetyEquipments_SafetyEquipmentId",
                        column: x => x.SafetyEquipmentId,
                        principalTable: "SafetyEquipments",
                        principalColumn: "SafetyEquipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChemicalHasCheckLists",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    CheckListId = table.Column<int>(nullable: true),
                    ChemicalHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChemicalWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    ChemicalHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChemicalWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    CheckListId = table.Column<int>(nullable: true),
                    ColdHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColdWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    ColdHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColdWorkPermitId = table.Column<int>(nullable: true)
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
                name: "ConfinedHasCheckLists",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    CheckListId = table.Column<int>(nullable: true),
                    ConfinedHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConfinedSpacePermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfinedHasCheckLists", x => x.ConfinedHasCheckListId);
                    table.ForeignKey(
                        name: "FK_ConfinedHasCheckLists_ConfinedSpaceWorkPermits_ConfinedSpacePermitId",
                        column: x => x.ConfinedSpacePermitId,
                        principalTable: "ConfinedSpaceWorkPermits",
                        principalColumn: "ConfinedSpaceWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfinedHasEmpHelps",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ConfinedHasEmpHelpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    ConfinedSpacePermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfinedHasEmpHelps", x => x.ConfinedHasEmpHelpId);
                    table.ForeignKey(
                        name: "FK_ConfinedHasEmpHelps_ConfinedSpaceWorkPermits_ConfinedSpacePermitId",
                        column: x => x.ConfinedSpacePermitId,
                        principalTable: "ConfinedSpaceWorkPermits",
                        principalColumn: "ConfinedSpaceWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfinedHasEmpWorks",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ConfinedHasEmpWorkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpCode = table.Column<string>(maxLength: 50, nullable: true),
                    ConfinedSpacePermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfinedHasEmpWorks", x => x.ConfinedHasEmpWorkId);
                    table.ForeignKey(
                        name: "FK_ConfinedHasEmpWorks_ConfinedSpaceWorkPermits_ConfinedSpacePermitId",
                        column: x => x.ConfinedSpacePermitId,
                        principalTable: "ConfinedSpaceWorkPermits",
                        principalColumn: "ConfinedSpaceWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfinedHasEquips",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    ConfinedHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConfinedSpacePermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfinedHasEquips", x => x.ConfinedHasEquipId);
                    table.ForeignKey(
                        name: "FK_ConfinedHasEquips_ConfinedSpaceWorkPermits_ConfinedSpacePermitId",
                        column: x => x.ConfinedSpacePermitId,
                        principalTable: "ConfinedSpaceWorkPermits",
                        principalColumn: "ConfinedSpaceWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectricalHasCheckLists",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    CheckListId = table.Column<int>(nullable: true),
                    ElectricalHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElectricalPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    ElectricalHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElectricalPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    CheckListId = table.Column<int>(nullable: true),
                    HeightHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HeightWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    HeightHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HeightWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    CheckListId = table.Column<int>(nullable: true),
                    HotHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    HasHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    CheckListId = table.Column<int>(nullable: true),
                    MachineHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MachineAtWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    MachineHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MachineAtWorkPermitId = table.Column<int>(nullable: true)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    CheckListId = table.Column<int>(nullable: true),
                    PressureHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    PressureHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PressureWorkPermitId = table.Column<int>(nullable: false)
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    CheckListId = table.Column<int>(nullable: true),
                    RayHasCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HasCheck = table.Column<bool>(nullable: true),
                    SafetyEquipmentId = table.Column<int>(nullable: true),
                    RayHasEquipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RayWorkPermitId = table.Column<int>(nullable: true)
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
                name: "IX_ApprovedFlowDetails_ApprovedFlowMasterId",
                table: "ApprovedFlowDetails",
                column: "ApprovedFlowMasterId");

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
                name: "IX_ConfinedHasCheckLists_ConfinedSpacePermitId",
                table: "ConfinedHasCheckLists",
                column: "ConfinedSpacePermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfinedHasEmpHelps_ConfinedSpacePermitId",
                table: "ConfinedHasEmpHelps",
                column: "ConfinedSpacePermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfinedHasEmpWorks_ConfinedSpacePermitId",
                table: "ConfinedHasEmpWorks",
                column: "ConfinedSpacePermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfinedHasEquips_ConfinedSpacePermitId",
                table: "ConfinedHasEquips",
                column: "ConfinedSpacePermitId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfinedSpaceWorkPermits_GroupWorkPermitId",
                table: "ConfinedSpaceWorkPermits",
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
                name: "IX_GroupPermitHasCheckLists_CheckListId",
                table: "GroupPermitHasCheckLists",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPermitHasCheckLists_GroupWorkPermitId",
                table: "GroupPermitHasCheckLists",
                column: "GroupWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPermitHasEquipments_GroupWorkPermitId",
                table: "GroupPermitHasEquipments",
                column: "GroupWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPermitHasEquipments_SafetyEquipmentId",
                table: "GroupPermitHasEquipments",
                column: "SafetyEquipmentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TypeWorkPermits_GroupWorkPermitId",
                table: "TypeWorkPermits",
                column: "GroupWorkPermitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovedFlowDetails");

            migrationBuilder.DropTable(
                name: "ChemicalHasCheckLists");

            migrationBuilder.DropTable(
                name: "ChemicalHasEquips");

            migrationBuilder.DropTable(
                name: "ColdHasCheckLists");

            migrationBuilder.DropTable(
                name: "ColdHasEquips");

            migrationBuilder.DropTable(
                name: "ConfinedHasCheckLists");

            migrationBuilder.DropTable(
                name: "ConfinedHasEmpHelps");

            migrationBuilder.DropTable(
                name: "ConfinedHasEmpWorks");

            migrationBuilder.DropTable(
                name: "ConfinedHasEquips");

            migrationBuilder.DropTable(
                name: "ElectricalHasCheckLists");

            migrationBuilder.DropTable(
                name: "ElectricalHasEquips");

            migrationBuilder.DropTable(
                name: "GroupPermitHasCheckLists");

            migrationBuilder.DropTable(
                name: "GroupPermitHasEquipments");

            migrationBuilder.DropTable(
                name: "HeightHasCheckLists");

            migrationBuilder.DropTable(
                name: "HeightHasEquips");

            migrationBuilder.DropTable(
                name: "HotHasCheckList");

            migrationBuilder.DropTable(
                name: "HotHasEquips");

            migrationBuilder.DropTable(
                name: "Lifting1WorkPermit");

            migrationBuilder.DropTable(
                name: "MachineHasCheckLists");

            migrationBuilder.DropTable(
                name: "MachineHasEquips");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PressureHasCheckList");

            migrationBuilder.DropTable(
                name: "PressureHasEquips");

            migrationBuilder.DropTable(
                name: "RayHasCheckLists");

            migrationBuilder.DropTable(
                name: "RayHasEquips");

            migrationBuilder.DropTable(
                name: "TypeWorkPermits");

            migrationBuilder.DropTable(
                name: "ApprovedFlowMasters");

            migrationBuilder.DropTable(
                name: "ChemicalWorkPermits");

            migrationBuilder.DropTable(
                name: "ColdWorkPermits");

            migrationBuilder.DropTable(
                name: "ConfinedSpaceWorkPermits");

            migrationBuilder.DropTable(
                name: "ElectricalWorkPermits");

            migrationBuilder.DropTable(
                name: "CheckLists");

            migrationBuilder.DropTable(
                name: "SafetyEquipments");

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

            migrationBuilder.DropTable(
                name: "GroupWorkPermits");
        }
    }
}

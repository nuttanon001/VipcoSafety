using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class updatePercaution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfinedHasPrecautions",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Risk = table.Column<string>(maxLength: 200, nullable: true),
                    Measure = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Remark = table.Column<string>(maxLength: 200, nullable: true),
                    ConfinedHasPreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConfinedSpaceWorkPermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfinedHasPrecautions", x => x.ConfinedHasPreId);
                    table.ForeignKey(
                        name: "FK_ConfinedHasPrecautions_ConfinedSpaceWorkPermits_ConfinedSpaceWorkPermitId",
                        column: x => x.ConfinedSpaceWorkPermitId,
                        principalTable: "ConfinedSpaceWorkPermits",
                        principalColumn: "ConfinedSpaceWorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LiftingHasPercaution",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Risk = table.Column<string>(maxLength: 200, nullable: true),
                    Measure = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Remark = table.Column<string>(maxLength: 200, nullable: true),
                    LiftingHasPerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lifting1WorkPermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingHasPercaution", x => x.LiftingHasPerId);
                    table.ForeignKey(
                        name: "FK_LiftingHasPercaution_Lifting1WorkPermit_Lifting1WorkPermitId",
                        column: x => x.Lifting1WorkPermitId,
                        principalTable: "Lifting1WorkPermit",
                        principalColumn: "Lifting1WorkPermitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfinedHasPrecautions_ConfinedSpaceWorkPermitId",
                table: "ConfinedHasPrecautions",
                column: "ConfinedSpaceWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingHasPercaution_Lifting1WorkPermitId",
                table: "LiftingHasPercaution",
                column: "Lifting1WorkPermitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfinedHasPrecautions");

            migrationBuilder.DropTable(
                name: "LiftingHasPercaution");
        }
    }
}

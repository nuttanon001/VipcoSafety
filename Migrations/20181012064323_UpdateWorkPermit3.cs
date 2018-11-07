using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class UpdateWorkPermit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedByEmpName",
                table: "RayWorkPermits",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "RayWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByEmpName",
                table: "PressureWorkPermits",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "PressureWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByEmpName",
                table: "MachineAtWorkPermits",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "MachineAtWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByEmpName",
                table: "HotWorkPermits",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "HotWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByEmpName",
                table: "HeightWorkPermit",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "HeightWorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByEmpName",
                table: "ElectricalWorkPermits",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "ElectricalWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByEmpName",
                table: "ConfinedSpaceWorkPermits",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "ConfinedSpaceWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByEmpName",
                table: "ColdWorkPermits",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "ColdWorkPermits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByEmpName",
                table: "ChemicalWorkPermits",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "ChemicalWorkPermits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedByEmpName",
                table: "RayWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "RayWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedByEmpName",
                table: "PressureWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "PressureWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedByEmpName",
                table: "MachineAtWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "MachineAtWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedByEmpName",
                table: "HotWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "HotWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedByEmpName",
                table: "HeightWorkPermit");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "HeightWorkPermit");

            migrationBuilder.DropColumn(
                name: "ApprovedByEmpName",
                table: "ElectricalWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "ElectricalWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedByEmpName",
                table: "ConfinedSpaceWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "ConfinedSpaceWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedByEmpName",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedByEmpName",
                table: "ChemicalWorkPermits");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "ChemicalWorkPermits");
        }
    }
}

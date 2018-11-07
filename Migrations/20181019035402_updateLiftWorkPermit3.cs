using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class updateLiftWorkPermit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LiftFinishDate",
                table: "Lifting1WorkPermit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LiftFinishDateTimeString",
                table: "Lifting1WorkPermit",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiftFinishDate",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "LiftFinishDateTimeString",
                table: "Lifting1WorkPermit");
        }
    }
}

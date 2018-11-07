using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoSafety.Migrations
{
    public partial class updateLifting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedByEmpName",
                table: "Lifting1WorkPermit",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "Lifting1WorkPermit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedByEmpName",
                table: "Lifting1WorkPermit");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "Lifting1WorkPermit");
        }
    }
}

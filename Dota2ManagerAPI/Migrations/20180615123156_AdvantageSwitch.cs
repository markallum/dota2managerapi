using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Dota2ManagerAPI.Migrations
{
    public partial class AdvantageSwitch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Disadvantage",
                table: "WinRatesVersus",
                newName: "Advantage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Advantage",
                table: "WinRatesVersus",
                newName: "Disadvantage");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

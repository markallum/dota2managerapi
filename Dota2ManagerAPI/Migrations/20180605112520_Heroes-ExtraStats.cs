using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Dota2ManagerAPI.Migrations
{
    public partial class HeroesExtraStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Awareness",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Efficiency",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Poise",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Positioning",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Awareness",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Efficiency",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Poise",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Positioning",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Heroes");
        }
    }
}

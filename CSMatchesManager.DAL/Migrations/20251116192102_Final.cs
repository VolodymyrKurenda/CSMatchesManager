using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMatchesManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firstmatch",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "AVGDamange",
                table: "Statistics",
                newName: "AVGDamage");

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Players",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "KD",
                table: "Players",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AVGDamage",
                table: "Statistics",
                newName: "AVGDamange");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "KD",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<DateTime>(
                name: "Firstmatch",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

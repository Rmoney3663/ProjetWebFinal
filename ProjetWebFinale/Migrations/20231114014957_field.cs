using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetWebFinale.Migrations
{
    public partial class field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MotPasse",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Utilisateurs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Utilisateurs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Utilisateurs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Utilisateurs",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Utilisateurs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Utilisateurs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "TypesUtilisateur",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TypesUtilisateur",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "TypesUtilisateur",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "TypesUtilisateur");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TypesUtilisateur");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "TypesUtilisateur");

            migrationBuilder.AlterColumn<int>(
                name: "MotPasse",
                table: "Utilisateurs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

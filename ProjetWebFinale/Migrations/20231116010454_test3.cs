using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetWebFinale.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifiant",
                table: "AspNetRoles",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifiant",
                table: "AspNetRoles");
        }
    }
}

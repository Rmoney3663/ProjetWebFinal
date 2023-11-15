using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetWebFinale.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Formats_NoUtilisateurProprietaire",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "NoLangue",
                table: "Langues");

            migrationBuilder.AddColumn<string>(
                name: "Langue",
                table: "Langues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Films_Format",
                table: "Films",
                column: "Format");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Formats_Format",
                table: "Films",
                column: "Format",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Formats_Format",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_Format",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Langue",
                table: "Langues");

            migrationBuilder.AddColumn<int>(
                name: "NoLangue",
                table: "Langues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Formats_NoUtilisateurProprietaire",
                table: "Films",
                column: "NoUtilisateurProprietaire",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

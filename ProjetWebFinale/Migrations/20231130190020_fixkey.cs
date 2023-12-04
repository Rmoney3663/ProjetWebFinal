using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetWebFinale.Migrations
{
    public partial class fixkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Categories_NoUtilisateurProprietaire",
                table: "Films");

            migrationBuilder.AlterColumn<string>(
                name: "Xtra",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Films_Categorie",
                table: "Films",
                column: "Categorie");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Categories_Categorie",
                table: "Films",
                column: "Categorie",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Categories_Categorie",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_Categorie",
                table: "Films");

            migrationBuilder.AlterColumn<string>(
                name: "Xtra",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Categories_NoUtilisateurProprietaire",
                table: "Films",
                column: "NoUtilisateurProprietaire",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

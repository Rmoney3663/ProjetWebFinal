using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetWebFinale.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpruntsFilms_Utilisateurs_NoUtilisateur",
                table: "EmpruntsFilms");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_Formats_NoUtilisateurProprietaire",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_Utilisateurs_NoUtilisateurMAJ",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_Utilisateurs_NoUtilisateurProprietaire",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilisateursPreferences_Utilisateurs_NoUtilisateur",
                table: "UtilisateursPreferences");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "TypesUtilisateur");

            migrationBuilder.DropColumn(
                name: "NoLangue",
                table: "Langues");

            migrationBuilder.AddColumn<string>(
                name: "Langue",
                table: "Langues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Courriel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MotPasse",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomUtilisateur",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeUtilisateur",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Films_Format",
                table: "Films",
                column: "Format");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TypeUtilisateur",
                table: "AspNetUsers",
                column: "TypeUtilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_TypeUtilisateur",
                table: "AspNetUsers",
                column: "TypeUtilisateur",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpruntsFilms_AspNetUsers_NoUtilisateur",
                table: "EmpruntsFilms",
                column: "NoUtilisateur",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_AspNetUsers_NoUtilisateurMAJ",
                table: "Films",
                column: "NoUtilisateurMAJ",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_AspNetUsers_NoUtilisateurProprietaire",
                table: "Films",
                column: "NoUtilisateurProprietaire",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Formats_Format",
                table: "Films",
                column: "Format",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UtilisateursPreferences_AspNetUsers_NoUtilisateur",
                table: "UtilisateursPreferences",
                column: "NoUtilisateur",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_TypeUtilisateur",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpruntsFilms_AspNetUsers_NoUtilisateur",
                table: "EmpruntsFilms");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_AspNetUsers_NoUtilisateurMAJ",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_AspNetUsers_NoUtilisateurProprietaire",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_Formats_Format",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilisateursPreferences_AspNetUsers_NoUtilisateur",
                table: "UtilisateursPreferences");

            migrationBuilder.DropIndex(
                name: "IX_Films_Format",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TypeUtilisateur",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Langue",
                table: "Langues");

            migrationBuilder.DropColumn(
                name: "Courriel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MotPasse",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NomUtilisateur",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TypeUtilisateur",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<int>(
                name: "NoLangue",
                table: "Langues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "TypesUtilisateur",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesUtilisateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeUtilisateur = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotPasse = table.Column<int>(type: "int", nullable: false),
                    NomUtilisateur = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_TypesUtilisateur_TypeUtilisateur",
                        column: x => x.TypeUtilisateur,
                        principalTable: "TypesUtilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_TypeUtilisateur",
                table: "Utilisateurs",
                column: "TypeUtilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpruntsFilms_Utilisateurs_NoUtilisateur",
                table: "EmpruntsFilms",
                column: "NoUtilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Formats_NoUtilisateurProprietaire",
                table: "Films",
                column: "NoUtilisateurProprietaire",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Utilisateurs_NoUtilisateurMAJ",
                table: "Films",
                column: "NoUtilisateurMAJ",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Utilisateurs_NoUtilisateurProprietaire",
                table: "Films",
                column: "NoUtilisateurProprietaire",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UtilisateursPreferences_Utilisateurs_NoUtilisateur",
                table: "UtilisateursPreferences",
                column: "NoUtilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

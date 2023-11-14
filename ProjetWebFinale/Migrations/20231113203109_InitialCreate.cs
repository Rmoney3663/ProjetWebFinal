using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetWebFinale.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexe = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Langues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoLangue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Realisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SousTitres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LangueSousTitre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousTitres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplements", x => x.Id);
                });

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
                name: "ValeursPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoPreference = table.Column<int>(type: "int", nullable: false),
                    Valeur = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValeursPreferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomUtilisateur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotPasse = table.Column<int>(type: "int", nullable: false),
                    TypeUtilisateur = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    TypesUtilisateurId = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_TypesUtilisateur_TypesUtilisateurId",
                        column: x => x.TypesUtilisateurId,
                        principalTable: "TypesUtilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exemplaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoUtilisateurProprietaire = table.Column<int>(type: "int", nullable: false),
                    UtilisateursId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemplaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exemplaires_Utilisateurs_UtilisateursId",
                        column: x => x.UtilisateursId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnneeSortie = table.Column<int>(type: "int", nullable: false),
                    Categorie = table.Column<int>(type: "int", nullable: false),
                    Format = table.Column<int>(type: "int", nullable: false),
                    DateMAJ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoUtilisateurMAJ = table.Column<int>(type: "int", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DureeMinutes = table.Column<int>(type: "int", nullable: false),
                    FilmOriginal = table.Column<bool>(type: "bit", nullable: false),
                    ImagePochette = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbDisques = table.Column<int>(type: "int", nullable: false),
                    TitreFrancais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitreOriginal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionEtendue = table.Column<bool>(type: "bit", nullable: false),
                    NoRealisateur = table.Column<int>(type: "int", nullable: false),
                    NoProducteur = table.Column<int>(type: "int", nullable: false),
                    Xtra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: true),
                    FormatsId = table.Column<int>(type: "int", nullable: true),
                    RealisateursId = table.Column<int>(type: "int", nullable: true),
                    ProducteursId = table.Column<int>(type: "int", nullable: true),
                    UtilisateursId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Films_Formats_FormatsId",
                        column: x => x.FormatsId,
                        principalTable: "Formats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Films_Producteurs_ProducteursId",
                        column: x => x.ProducteursId,
                        principalTable: "Producteurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Films_Realisateurs_RealisateursId",
                        column: x => x.RealisateursId,
                        principalTable: "Realisateurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Films_Utilisateurs_UtilisateursId",
                        column: x => x.UtilisateursId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UtilisateursPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoPreference = table.Column<int>(type: "int", nullable: false),
                    UtilisateursId = table.Column<int>(type: "int", nullable: true),
                    ValeursPreferencesId = table.Column<int>(type: "int", nullable: true),
                    PreferencesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilisateursPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UtilisateursPreferences_Preferences_PreferencesId",
                        column: x => x.PreferencesId,
                        principalTable: "Preferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UtilisateursPreferences_Utilisateurs_UtilisateursId",
                        column: x => x.UtilisateursId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UtilisateursPreferences_ValeursPreferences_ValeursPreferencesId",
                        column: x => x.ValeursPreferencesId,
                        principalTable: "ValeursPreferences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpruntsFilms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoUtilisateur = table.Column<int>(type: "int", nullable: false),
                    DateEmprunt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtilisateursId = table.Column<int>(type: "int", nullable: true),
                    ExemplairesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpruntsFilms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpruntsFilms_Exemplaires_ExemplairesId",
                        column: x => x.ExemplairesId,
                        principalTable: "Exemplaires",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpruntsFilms_Utilisateurs_UtilisateursId",
                        column: x => x.UtilisateursId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmsActeurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoActeur = table.Column<int>(type: "int", nullable: false),
                    ActeursId = table.Column<int>(type: "int", nullable: true),
                    FilmsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsActeurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmsActeurs_Acteurs_ActeursId",
                        column: x => x.ActeursId,
                        principalTable: "Acteurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilmsActeurs_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmsLangues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoLangue = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: true),
                    LanguesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsLangues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmsLangues_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilmsLangues_Langues_LanguesId",
                        column: x => x.LanguesId,
                        principalTable: "Langues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmsSousTitres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoSousTitre = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: true),
                    SousTitresId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsSousTitres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmsSousTitres_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilmsSousTitres_SousTitres_SousTitresId",
                        column: x => x.SousTitresId,
                        principalTable: "SousTitres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmsSupplements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoSupplement = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: true),
                    SupplementsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsSupplements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmsSupplements_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilmsSupplements_Supplements_SupplementsId",
                        column: x => x.SupplementsId,
                        principalTable: "Supplements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpruntsFilms_ExemplairesId",
                table: "EmpruntsFilms",
                column: "ExemplairesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpruntsFilms_UtilisateursId",
                table: "EmpruntsFilms",
                column: "UtilisateursId");

            migrationBuilder.CreateIndex(
                name: "IX_Exemplaires_UtilisateursId",
                table: "Exemplaires",
                column: "UtilisateursId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_CategoriesId",
                table: "Films",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_FormatsId",
                table: "Films",
                column: "FormatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_ProducteursId",
                table: "Films",
                column: "ProducteursId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_RealisateursId",
                table: "Films",
                column: "RealisateursId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_UtilisateursId",
                table: "Films",
                column: "UtilisateursId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsActeurs_ActeursId",
                table: "FilmsActeurs",
                column: "ActeursId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsActeurs_FilmsId",
                table: "FilmsActeurs",
                column: "FilmsId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsLangues_FilmsId",
                table: "FilmsLangues",
                column: "FilmsId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsLangues_LanguesId",
                table: "FilmsLangues",
                column: "LanguesId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsSousTitres_FilmsId",
                table: "FilmsSousTitres",
                column: "FilmsId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsSousTitres_SousTitresId",
                table: "FilmsSousTitres",
                column: "SousTitresId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsSupplements_FilmsId",
                table: "FilmsSupplements",
                column: "FilmsId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsSupplements_SupplementsId",
                table: "FilmsSupplements",
                column: "SupplementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_TypesUtilisateurId",
                table: "Utilisateurs",
                column: "TypesUtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateursPreferences_PreferencesId",
                table: "UtilisateursPreferences",
                column: "PreferencesId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateursPreferences_UtilisateursId",
                table: "UtilisateursPreferences",
                column: "UtilisateursId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateursPreferences_ValeursPreferencesId",
                table: "UtilisateursPreferences",
                column: "ValeursPreferencesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpruntsFilms");

            migrationBuilder.DropTable(
                name: "FilmsActeurs");

            migrationBuilder.DropTable(
                name: "FilmsLangues");

            migrationBuilder.DropTable(
                name: "FilmsSousTitres");

            migrationBuilder.DropTable(
                name: "FilmsSupplements");

            migrationBuilder.DropTable(
                name: "UtilisateursPreferences");

            migrationBuilder.DropTable(
                name: "Exemplaires");

            migrationBuilder.DropTable(
                name: "Acteurs");

            migrationBuilder.DropTable(
                name: "Langues");

            migrationBuilder.DropTable(
                name: "SousTitres");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Supplements");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "ValeursPreferences");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "Producteurs");

            migrationBuilder.DropTable(
                name: "Realisateurs");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "TypesUtilisateur");
        }
    }
}

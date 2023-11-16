﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetWebFinale.Models;

#nullable disable

namespace ProjetWebFinale.Migrations
{
    [DbContext(typeof(FilmDbContext))]
    partial class FilmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Acteurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("Acteurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.EmpruntsFilms", b =>
                {
                    b.Property<int>("NoFilm")
                        .HasColumnType("int");

                    b.Property<int>("NoUtilisateur")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEmprunt")
                        .HasColumnType("datetime2");

                    b.HasKey("NoFilm", "NoUtilisateur");

                    b.HasIndex("NoUtilisateur");

                    b.ToTable("EmpruntsFilms");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Films", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AnneeSortie")
                        .HasColumnType("int");

                    b.Property<int?>("Categorie")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateMAJ")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DureeMinutes")
                        .HasColumnType("int");

                    b.Property<bool?>("FilmOriginal")
                        .HasColumnType("bit");

                    b.Property<int?>("Format")
                        .HasColumnType("int");

                    b.Property<string>("ImagePochette")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NbDisques")
                        .HasColumnType("int");

                    b.Property<int?>("NoProducteur")
                        .HasColumnType("int");

                    b.Property<int?>("NoRealisateur")
                        .HasColumnType("int");

                    b.Property<int>("NoUtilisateurMAJ")
                        .HasColumnType("int");

                    b.Property<int>("NoUtilisateurProprietaire")
                        .HasColumnType("int");

                    b.Property<string>("Resume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitreFrancais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitreOriginal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("VersionEtendue")
                        .HasColumnType("bit");

                    b.Property<string>("Xtra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Format");

                    b.HasIndex("NoProducteur");

                    b.HasIndex("NoRealisateur");

                    b.HasIndex("NoUtilisateurMAJ");

                    b.HasIndex("NoUtilisateurProprietaire");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsActeurs", b =>
                {
                    b.Property<int>("NoFilm")
                        .HasColumnType("int");

                    b.Property<int>("NoActeur")
                        .HasColumnType("int");

                    b.HasKey("NoFilm", "NoActeur");

                    b.HasIndex("NoActeur");

                    b.ToTable("FilmsActeurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsLangues", b =>
                {
                    b.Property<int>("NoFilm")
                        .HasColumnType("int");

                    b.Property<int>("NoLangue")
                        .HasColumnType("int");

                    b.HasKey("NoFilm", "NoLangue");

                    b.HasIndex("NoLangue");

                    b.ToTable("FilmsLangues");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsSousTitres", b =>
                {
                    b.Property<int>("NoFilm")
                        .HasColumnType("int");

                    b.Property<int>("NoSousTitre")
                        .HasColumnType("int");

                    b.HasKey("NoFilm", "NoSousTitre");

                    b.HasIndex("NoSousTitre");

                    b.ToTable("FilmsSousTitres");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsSupplements", b =>
                {
                    b.Property<int>("NoFilm")
                        .HasColumnType("int");

                    b.Property<int>("NoSupplement")
                        .HasColumnType("int");

                    b.HasKey("NoFilm", "NoSupplement");

                    b.HasIndex("NoSupplement");

                    b.ToTable("FilmsSupplements");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Formats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Formats");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Langues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Langue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Langues");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Preferences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Producteurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producteurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Realisateurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Realisateurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.SousTitres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LangueSousTitre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SousTitres");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Supplements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supplements");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.TypesUtilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identifiant")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Utilisateurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Courriel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("MotPasse")
                        .HasColumnType("int");

                    b.Property<string>("NomUtilisateur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("TypeUtilisateur")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("TypeUtilisateur");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ProjetWebFinale.Models.UtilisateursPreferences", b =>
                {
                    b.Property<int>("NoUtilisateur")
                        .HasColumnType("int");

                    b.Property<int>("NoPreference")
                        .HasColumnType("int");

                    b.Property<string>("Valeur")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoUtilisateur", "NoPreference");

                    b.HasIndex("NoPreference");

                    b.ToTable("UtilisateursPreferences");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.TypesUtilisateur", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.TypesUtilisateur", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetWebFinale.Models.EmpruntsFilms", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Films", "Films")
                        .WithMany("EmpruntsFilms")
                        .HasForeignKey("NoFilm")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", "Utilisateurs")
                        .WithMany("EmpruntsFilms")
                        .HasForeignKey("NoUtilisateur")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Films");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Films", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Formats", "Formats")
                        .WithMany("Films")
                        .HasForeignKey("Format")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjetWebFinale.Models.Producteurs", "Producteurs")
                        .WithMany("Films")
                        .HasForeignKey("NoProducteur")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjetWebFinale.Models.Realisateurs", "Realisateurs")
                        .WithMany("Films")
                        .HasForeignKey("NoRealisateur")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", "Utilisateurs")
                        .WithMany("Films")
                        .HasForeignKey("NoUtilisateurMAJ")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjetWebFinale.Models.Categories", "Categories")
                        .WithMany("Films")
                        .HasForeignKey("NoUtilisateurProprietaire")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", "UtilisateurProprietaire")
                        .WithMany("FilmProprietaire")
                        .HasForeignKey("NoUtilisateurProprietaire")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("Formats");

                    b.Navigation("Producteurs");

                    b.Navigation("Realisateurs");

                    b.Navigation("UtilisateurProprietaire");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsActeurs", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Acteurs", "Acteurs")
                        .WithMany("FilmsActeurs")
                        .HasForeignKey("NoActeur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetWebFinale.Models.Films", "Films")
                        .WithMany("FilmsActeurs")
                        .HasForeignKey("NoFilm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acteurs");

                    b.Navigation("Films");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsLangues", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Films", "Films")
                        .WithMany("FilmsLangues")
                        .HasForeignKey("NoFilm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetWebFinale.Models.Langues", "Langues")
                        .WithMany("FilmsLangues")
                        .HasForeignKey("NoLangue")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Films");

                    b.Navigation("Langues");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsSousTitres", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Films", "Films")
                        .WithMany("FilmsSousTitres")
                        .HasForeignKey("NoFilm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetWebFinale.Models.SousTitres", "SousTitres")
                        .WithMany("FilmsSousTitres")
                        .HasForeignKey("NoSousTitre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Films");

                    b.Navigation("SousTitres");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsSupplements", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Films", "Films")
                        .WithMany("FilmsSupplements")
                        .HasForeignKey("NoFilm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetWebFinale.Models.Supplements", "Supplements")
                        .WithMany("FilmsSupplements")
                        .HasForeignKey("NoSupplement")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Films");

                    b.Navigation("Supplements");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Utilisateurs", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.TypesUtilisateur", "TypesUtilisateur")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("TypeUtilisateur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypesUtilisateur");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.UtilisateursPreferences", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Preferences", "Preferences")
                        .WithMany("UtilisateursPreferences")
                        .HasForeignKey("NoPreference")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", "Utilisateurs")
                        .WithMany("UtilisateursPreferences")
                        .HasForeignKey("NoUtilisateur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Preferences");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Acteurs", b =>
                {
                    b.Navigation("FilmsActeurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Categories", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Films", b =>
                {
                    b.Navigation("EmpruntsFilms");

                    b.Navigation("FilmsActeurs");

                    b.Navigation("FilmsLangues");

                    b.Navigation("FilmsSousTitres");

                    b.Navigation("FilmsSupplements");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Formats", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Langues", b =>
                {
                    b.Navigation("FilmsLangues");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Preferences", b =>
                {
                    b.Navigation("UtilisateursPreferences");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Producteurs", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Realisateurs", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.SousTitres", b =>
                {
                    b.Navigation("FilmsSousTitres");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Supplements", b =>
                {
                    b.Navigation("FilmsSupplements");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.TypesUtilisateur", b =>
                {
                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Utilisateurs", b =>
                {
                    b.Navigation("EmpruntsFilms");

                    b.Navigation("FilmProprietaire");

                    b.Navigation("Films");

                    b.Navigation("UtilisateursPreferences");
                });
#pragma warning restore 612, 618
        }
    }
}

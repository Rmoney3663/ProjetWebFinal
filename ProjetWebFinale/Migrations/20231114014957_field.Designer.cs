﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetWebFinale.Models;

#nullable disable

namespace ProjetWebFinale.Migrations
{
    [DbContext(typeof(FilmDbContext))]
    [Migration("20231114014957_field")]
    partial class field
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateEmprunt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExemplairesId")
                        .HasColumnType("int");

                    b.Property<int>("NoUtilisateur")
                        .HasColumnType("int");

                    b.Property<int?>("UtilisateursId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExemplairesId");

                    b.HasIndex("UtilisateursId");

                    b.ToTable("EmpruntsFilms");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Exemplaires", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NoUtilisateurProprietaire")
                        .HasColumnType("int");

                    b.Property<int?>("UtilisateursId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilisateursId");

                    b.ToTable("Exemplaires");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Films", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnneeSortie")
                        .HasColumnType("int");

                    b.Property<int>("Categorie")
                        .HasColumnType("int");

                    b.Property<int?>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateMAJ")
                        .HasColumnType("datetime2");

                    b.Property<int>("DureeMinutes")
                        .HasColumnType("int");

                    b.Property<bool>("FilmOriginal")
                        .HasColumnType("bit");

                    b.Property<int>("Format")
                        .HasColumnType("int");

                    b.Property<int?>("FormatsId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePochette")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbDisques")
                        .HasColumnType("int");

                    b.Property<int>("NoProducteur")
                        .HasColumnType("int");

                    b.Property<int>("NoRealisateur")
                        .HasColumnType("int");

                    b.Property<int>("NoUtilisateurMAJ")
                        .HasColumnType("int");

                    b.Property<int?>("ProducteursId")
                        .HasColumnType("int");

                    b.Property<int?>("RealisateursId")
                        .HasColumnType("int");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitreFrancais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitreOriginal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UtilisateursId")
                        .HasColumnType("int");

                    b.Property<bool>("VersionEtendue")
                        .HasColumnType("bit");

                    b.Property<string>("Xtra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("FormatsId");

                    b.HasIndex("ProducteursId");

                    b.HasIndex("RealisateursId");

                    b.HasIndex("UtilisateursId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsActeurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ActeursId")
                        .HasColumnType("int");

                    b.Property<int?>("FilmsId")
                        .HasColumnType("int");

                    b.Property<int>("NoActeur")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActeursId");

                    b.HasIndex("FilmsId");

                    b.ToTable("FilmsActeurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsLangues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FilmsId")
                        .HasColumnType("int");

                    b.Property<int?>("LanguesId")
                        .HasColumnType("int");

                    b.Property<int>("NoLangue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmsId");

                    b.HasIndex("LanguesId");

                    b.ToTable("FilmsLangues");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsSousTitres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FilmsId")
                        .HasColumnType("int");

                    b.Property<int>("NoSousTitre")
                        .HasColumnType("int");

                    b.Property<int?>("SousTitresId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmsId");

                    b.HasIndex("SousTitresId");

                    b.ToTable("FilmsSousTitres");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsSupplements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FilmsId")
                        .HasColumnType("int");

                    b.Property<int>("NoSupplement")
                        .HasColumnType("int");

                    b.Property<int?>("SupplementsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmsId");

                    b.HasIndex("SupplementsId");

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

                    b.Property<int>("NoLangue")
                        .HasColumnType("int");

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
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesUtilisateur");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Courriel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MotPasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomUtilisateur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("TypeUtilisateur")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("TypesUtilisateurId")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TypesUtilisateurId");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.UtilisateursPreferences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NoPreference")
                        .HasColumnType("int");

                    b.Property<int?>("PreferencesId")
                        .HasColumnType("int");

                    b.Property<int?>("UtilisateursId")
                        .HasColumnType("int");

                    b.Property<int?>("ValeursPreferencesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreferencesId");

                    b.HasIndex("UtilisateursId");

                    b.HasIndex("ValeursPreferencesId");

                    b.ToTable("UtilisateursPreferences");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.ValeursPreferences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NoPreference")
                        .HasColumnType("int");

                    b.Property<string>("Valeur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ValeursPreferences");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.EmpruntsFilms", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Exemplaires", "Exemplaires")
                        .WithMany("EmpruntsFilms")
                        .HasForeignKey("ExemplairesId");

                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", "Utilisateurs")
                        .WithMany("EmpruntsFilms")
                        .HasForeignKey("UtilisateursId");

                    b.Navigation("Exemplaires");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Exemplaires", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", "Utilisateurs")
                        .WithMany("Exemplaires")
                        .HasForeignKey("UtilisateursId");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Films", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Categories", "Categories")
                        .WithMany("Films")
                        .HasForeignKey("CategoriesId");

                    b.HasOne("ProjetWebFinale.Models.Formats", "Formats")
                        .WithMany("Films")
                        .HasForeignKey("FormatsId");

                    b.HasOne("ProjetWebFinale.Models.Producteurs", "Producteurs")
                        .WithMany("Films")
                        .HasForeignKey("ProducteursId");

                    b.HasOne("ProjetWebFinale.Models.Realisateurs", "Realisateurs")
                        .WithMany("Films")
                        .HasForeignKey("RealisateursId");

                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", "Utilisateurs")
                        .WithMany("Films")
                        .HasForeignKey("UtilisateursId");

                    b.Navigation("Categories");

                    b.Navigation("Formats");

                    b.Navigation("Producteurs");

                    b.Navigation("Realisateurs");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsActeurs", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Acteurs", "Acteurs")
                        .WithMany("FilmsActeurs")
                        .HasForeignKey("ActeursId");

                    b.HasOne("ProjetWebFinale.Models.Films", "Films")
                        .WithMany("FilmsActeurs")
                        .HasForeignKey("FilmsId");

                    b.Navigation("Acteurs");

                    b.Navigation("Films");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsLangues", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Films", "Films")
                        .WithMany("FilmsLangues")
                        .HasForeignKey("FilmsId");

                    b.HasOne("ProjetWebFinale.Models.Langues", "Langues")
                        .WithMany("FilmsLangues")
                        .HasForeignKey("LanguesId");

                    b.Navigation("Films");

                    b.Navigation("Langues");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsSousTitres", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Films", "Films")
                        .WithMany("FilmsSousTitres")
                        .HasForeignKey("FilmsId");

                    b.HasOne("ProjetWebFinale.Models.SousTitres", "SousTitres")
                        .WithMany("FilmsSousTitres")
                        .HasForeignKey("SousTitresId");

                    b.Navigation("Films");

                    b.Navigation("SousTitres");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.FilmsSupplements", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Films", "Films")
                        .WithMany("FilmsSupplements")
                        .HasForeignKey("FilmsId");

                    b.HasOne("ProjetWebFinale.Models.Supplements", "Supplements")
                        .WithMany("FilmsSupplements")
                        .HasForeignKey("SupplementsId");

                    b.Navigation("Films");

                    b.Navigation("Supplements");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Utilisateurs", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.TypesUtilisateur", "TypesUtilisateur")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("TypesUtilisateurId");

                    b.Navigation("TypesUtilisateur");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.UtilisateursPreferences", b =>
                {
                    b.HasOne("ProjetWebFinale.Models.Preferences", "Preferences")
                        .WithMany()
                        .HasForeignKey("PreferencesId");

                    b.HasOne("ProjetWebFinale.Models.Utilisateurs", "Utilisateurs")
                        .WithMany("UtilisateursPreferences")
                        .HasForeignKey("UtilisateursId");

                    b.HasOne("ProjetWebFinale.Models.ValeursPreferences", "ValeursPreferences")
                        .WithMany()
                        .HasForeignKey("ValeursPreferencesId");

                    b.Navigation("Preferences");

                    b.Navigation("Utilisateurs");

                    b.Navigation("ValeursPreferences");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Acteurs", b =>
                {
                    b.Navigation("FilmsActeurs");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Categories", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Exemplaires", b =>
                {
                    b.Navigation("EmpruntsFilms");
                });

            modelBuilder.Entity("ProjetWebFinale.Models.Films", b =>
                {
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

                    b.Navigation("Exemplaires");

                    b.Navigation("Films");

                    b.Navigation("UtilisateursPreferences");
                });
#pragma warning restore 612, 618
        }
    }
}

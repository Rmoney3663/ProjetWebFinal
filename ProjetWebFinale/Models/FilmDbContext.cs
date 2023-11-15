using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ProjetWebFinale.Models
{
    public class FilmDbContext : IdentityDbContext<Utilisateurs, TypesUtilisateur, int>
    {
        public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<Acteurs> Acteurs { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<EmpruntsFilms> EmpruntsFilms { get; set; }
        //public DbSet<Exemplaires> Exemplaires { get; set; }
        public DbSet<Films> Films { get; set; }
        public DbSet<FilmsActeurs> FilmsActeurs { get; set; }
        public DbSet<FilmsLangues> FilmsLangues { get; set; }
        public DbSet<FilmsSousTitres> FilmsSousTitres { get; set; }
        public DbSet<FilmsSupplements> FilmsSupplements { get; set; }
        public DbSet<Formats> Formats { get; set; }
        public DbSet<Langues> Langues { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
        public DbSet<Producteurs> Producteurs { get; set; }
        public DbSet<Realisateurs> Realisateurs { get; set; }
        public DbSet<SousTitres> SousTitres { get; set; }
        public DbSet<Supplements> Supplements { get; set; }
        public DbSet<TypesUtilisateur> TypesUtilisateur { get; set; }
        public DbSet<Utilisateurs> Utilisateurs { get; set; }
        public DbSet<UtilisateursPreferences> UtilisateursPreferences { get; set; }
        // public DbSet<ValeursPreferences> ValeursPreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmpruntsFilms>()
                .HasOne<Utilisateurs>(e => e.Utilisateurs)
                .WithMany(u => u.EmpruntsFilms)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmpruntsFilms>()
                .HasOne<Films>(e => e.Films)
                .WithMany(u => u.EmpruntsFilms)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Films>()
               .HasOne<Categories>(e => e.Categories)
               .WithMany(u => u.Films)
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Films>()
                .HasOne<Formats>(e => e.Formats)
                .WithMany(u => u.Films)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Films>()
               .HasOne<Realisateurs>(e => e.Realisateurs)
               .WithMany(u => u.Films)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Films>()
               .HasOne<Producteurs>(e => e.Producteurs)
               .WithMany(u => u.Films)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Films>()
               .HasOne<Utilisateurs>(e => e.Utilisateurs)
               .WithMany(u => u.Films)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Films>()
               .HasOne<Utilisateurs>(e => e.UtilisateurProprietaire)
               .WithMany(u => u.FilmProprietaire)
               .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<EmpruntsFilms>().HasKey(m => new { m.NoFilm, m.NoUtilisateur });


            modelBuilder.Entity<UtilisateursPreferences>().HasKey(m => new { m.NoUtilisateur, m.NoPreference });


            modelBuilder.Entity<FilmsActeurs>().HasKey(m => new { m.NoFilm, m.NoActeur});
            
            modelBuilder.Entity<FilmsSupplements>().HasKey(m => new { m.NoFilm, m.NoSupplement });


            modelBuilder.Entity<FilmsLangues>().HasKey(m => new { m.NoFilm, m.NoLangue });


            modelBuilder.Entity<FilmsSousTitres>().HasKey(m => new { m.NoFilm, m.NoSousTitre });




        }

    }
}
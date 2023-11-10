using Microsoft.EntityFrameworkCore;
namespace ProjetWebFinale.Models
{
    public class FilmDbContext : DbContext
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
        public DbSet<Exemplaires> Exemplaires { get; set; }
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
        public DbSet<ValeursPreferences> ValeursPreferences { get; set; }

    }
}
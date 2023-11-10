using Microsoft.EntityFrameworkCore;

namespace ProjetWebFinale.Models
{
    public class DVDDbContext
    {
        public DVDDbContext(DbContextOptions<DVDDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<DVD> DVD { get; set; }
        public DbSet<Categorie> Categorie { get; set; }

    }
}

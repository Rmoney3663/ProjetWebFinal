using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetWebFinale.Areas.Identity.Data;
using ProjetWebFinale.Models;

namespace ProjetWebFinale.Areas.Identity.Data;

public class IdentityDBContext : IdentityDbContext<Utilisateurs, TypesUtilisateur, string>
{
    public IdentityDBContext(DbContextOptions<IdentityDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class Utilisateurs: IdentityUser
    {
        public int Id { get; set; }
        public string NomUtilisateur { get; set; }
        public string Courriel { get; set; }
        public string MotPasse { get; set; }
        public char TypeUtilisateur { get; set; }
        public virtual TypesUtilisateur? TypesUtilisateur { get; set; }
        public virtual ICollection<Films>? Films { get; set; }
        public virtual ICollection<Exemplaires>? Exemplaires { get; set; }
        public virtual ICollection<EmpruntsFilms>? EmpruntsFilms { get; set; }
        public virtual ICollection<UtilisateursPreferences>? UtilisateursPreferences { get; set; }

    }
}

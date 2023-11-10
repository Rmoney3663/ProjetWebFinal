using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class Utilisateurs
    {
        public int NoUtilisateur { get; set; }
        public string NomUtilisateur { get; set; }
        public string Courriel { get; set; }
        public int MotPasse { get; set; }
        public char TypeUtilisateur { get; set; }
        public virtual TypesUtilisateur? TypesUtilisateur { get; set; }
        public virtual ICollection<Films>? Films { get; set; }
        public virtual ICollection<Exemplaires>? Exemplaires { get; set; }
        public virtual ICollection<EmpruntsFilms>? EmpruntsFilms { get; set; }
        public virtual ICollection<UtilisateursPreferences>? UtilisateursPreferences { get; set; }

    }
}

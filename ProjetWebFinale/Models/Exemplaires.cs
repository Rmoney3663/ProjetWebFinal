using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class Exemplaires
    {
        public int Id { get; set; }
        public int NoUtilisateurProprietaire { get; set; }
        public virtual Utilisateurs? Utilisateurs { get; set; }
        public virtual ICollection<EmpruntsFilms>? EmpruntsFilms { get; set; }
    }
}

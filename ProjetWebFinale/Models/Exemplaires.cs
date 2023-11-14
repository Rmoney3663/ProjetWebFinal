using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class Exemplaires
    {
        public int Id { get; set; }
        public int NoUtilisateurProprietaire { get; set; }
        [ForeignKey("NoUtilisateurProprietaire")]
        [InverseProperty("Exemplaires")]
        public virtual Utilisateurs? Utilisateurs { get; set; }
        [InverseProperty("Exemplaires")]
        public virtual ICollection<EmpruntsFilms>? EmpruntsFilms { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class EmpruntsFilms
    {
        public int NoExemplaire { get; set; }
        public int NoUtilisateur { get; set; }

        public DateTime DateEmprunt { get; set; }
        public virtual Utilisateurs? Utilisateurs { get; set; }
        public virtual Exemplaires? Exemplaires { get; set; }
    }
}

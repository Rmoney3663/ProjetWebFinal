using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class EmpruntsFilms
    {
        public int Id { get; set; }
        public int NoUtilisateur { get; set; }

        public DateTime DateEmprunt { get; set; }
        public virtual Utilisateurs? Utilisateurs { get; set; }
        public virtual Exemplaires? Exemplaires { get; set; }
    }
}

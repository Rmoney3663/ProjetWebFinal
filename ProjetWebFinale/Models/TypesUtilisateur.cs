using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class TypesUtilisateur
    {
        public char Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Utilisateurs>? Utilisateurs { get; set; }
    }
}

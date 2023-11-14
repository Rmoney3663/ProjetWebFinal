using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class Realisateurs
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual ICollection<Films>? Films { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class Realisateurs
    {
        public int NoRealisateur { get; set; }
        public string Nom { get; set; }
        public virtual ICollection<Films>? Films { get; set; }
    }
}

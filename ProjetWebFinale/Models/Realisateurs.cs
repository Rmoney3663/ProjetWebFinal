using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class Realisateurs
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [InverseProperty("Realisateurs")]
        public virtual ICollection<Films>? Films { get; set; }
    }
}

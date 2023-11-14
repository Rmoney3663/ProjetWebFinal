using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class Producteurs
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [InverseProperty("Producteurs")]
        public virtual ICollection<Films>? Films { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class Acteurs
    {
        public int Id { get; set; }
        
        public string Nom { get; set; }

        public char Sexe { get; set; }
        [InverseProperty("Acteurs")]
        public virtual ICollection<FilmsActeurs>? FilmsActeurs { get; set; }


    }
}

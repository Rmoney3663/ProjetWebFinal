using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class SousTitres
    {
        public int Id { get; set; }
        public string LangueSousTitre { get; set; }
        [InverseProperty("SousTitres")]
        public virtual ICollection<FilmsSousTitres>? FilmsSousTitres { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class SousTitres
    {
        public int NoSousTitre { get; set; }
        public string LangueSousTitre { get; set; }
        public virtual ICollection<FilmsSousTitres>? FilmsSousTitres { get; set; }
    }
}

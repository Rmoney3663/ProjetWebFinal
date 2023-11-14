using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class FilmsSousTitres
    {
        public int NoFilm { get; set; }
        public int NoSousTitre { get; set; }
        [ForeignKey("NoFilm")]
        [InverseProperty("FilmsSousTitres")]
        public virtual Films? Films { get; set; }
        [ForeignKey("NoSousTitre")]
        [InverseProperty("FilmsSousTitres")]
        public virtual SousTitres? SousTitres { get; set; }
    }
}

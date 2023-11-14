using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class FilmsActeurs
    {
        public int NoFilm { get; set; }
        public int NoActeur { get; set; }
        [ForeignKey("NoActeur")]
        [InverseProperty("FilmsActeurs")]
        public virtual Acteurs? Acteurs { get; set; }
        [ForeignKey("NoFilm")]
        [InverseProperty("FilmsActeurs")]
        public virtual Films? Films { get; set; }
    }
}

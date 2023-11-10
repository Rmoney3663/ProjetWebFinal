using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class FilmsActeurs
    {
        public int NoFilm { get; set; }
        public int NoActeur { get; set; }
        public virtual Acteurs? Acteurs { get; set; }
        public virtual Films? Films { get; set; }
    }
}

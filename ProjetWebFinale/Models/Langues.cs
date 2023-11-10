namespace ProjetWebFinale.Models
{
    public class Langues
    {
        public int NoFilm { get; set; }
        public int NoLangue { get; set; }
        public virtual ICollection<FilmsLangues>? FilmsLangues { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;    
namespace ProjetWebFinale.Models
{
    public class Films
    {
        public int Id { get; set; }
        public int? AnneeSortie { get; set; }
        public int? Categorie { get; set; }
        public int? Format { get; set; }
        public DateTime DateMAJ { get; set; }

        public int NoUtilisateurMAJ { get; set; }
        public string? Resume { get; set; }
        public int? DureeMinutes { get; set; }
        public bool? FilmOriginal { get; set; }
        public string? ImagePochette { get; set; }
        public int? NbDisques { get; set; }
        [Required]
        public string TitreFrancais { get; set; }
        public string? TitreOriginal { get; set; }
        public bool? VersionEtendue { get; set; }
        public int? NoRealisateur { get; set; }
        public int? NoProducteur { get; set; }
        public string Xtra { get; set; }

        public virtual ICollection<FilmsActeurs>? FilmsActeurs { get; set; }
        public virtual ICollection<FilmsSupplements>? FilmsSupplements { get; set; }
        public virtual ICollection<FilmsLangues>? FilmsLangues { get; set; }
        public virtual ICollection<FilmsSousTitres>? FilmsSousTitres { get; set; }
        public virtual Categories? Categories { get; set; }
        public virtual Formats? Formats { get; set; }
        public virtual Realisateurs? Realisateurs { get; set; }
        public virtual Producteurs? Producteurs { get; set; }
        public virtual Utilisateurs? Utilisateurs { get; set; }
    }
}

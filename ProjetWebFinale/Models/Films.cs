using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int NoUtilisateurProprietaire { get; set; }

        [InverseProperty("Films")]
        public virtual ICollection<FilmsActeurs>? FilmsActeurs { get; set; }
        
        [InverseProperty("Films")]
        public virtual ICollection<FilmsSupplements>? FilmsSupplements { get; set; }
       
        [InverseProperty("Films")]
        public virtual ICollection<FilmsLangues>? FilmsLangues { get; set; }
       
        [InverseProperty("Films")]
        public virtual ICollection<FilmsSousTitres>? FilmsSousTitres { get; set; }
        [ForeignKey("NoUtilisateurProprietaire")]
        [InverseProperty("Films")]
        public virtual Categories? Categories { get; set; }
        [ForeignKey("Format")]
        [InverseProperty("Films")]
        public virtual Formats? Formats { get; set; }
        [ForeignKey("NoRealisateur")]
        [InverseProperty("Films")]
        public virtual Realisateurs? Realisateurs { get; set; }
        [ForeignKey("NoProducteur")]
        [InverseProperty("Films")]
        public virtual Producteurs? Producteurs { get; set; }
        [ForeignKey("NoUtilisateurMAJ")]
        [InverseProperty("Films")]
        public virtual Utilisateurs? Utilisateurs { get; set; }
        [ForeignKey("NoUtilisateurProprietaire")]
        [InverseProperty("FilmProprietaire")]
        public virtual Utilisateurs? UtilisateurProprietaire { get; set; }

        [InverseProperty("Films")]
        public virtual ICollection<EmpruntsFilms>? EmpruntsFilms { get; set; }
    }
}

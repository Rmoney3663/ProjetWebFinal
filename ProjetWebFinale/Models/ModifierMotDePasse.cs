using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetWebFinale.Models
{
    public class ModifierMotDePasse
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Entrez votre mot de passe actuel")]
        public string ancienMotDePasse { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Entrez votre nouveau mot de passe")]
        public string nouveauMotDePasse { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer votre nouveau mot de passe")]
        [Compare("nouveauMotDePasse", ErrorMessage = "Votre nouveau mot de passe et sa confirmation ne sont pas équivalents.")]
        public string confirmerMotDePasse { get; set; }
    }
}

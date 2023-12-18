using System.ComponentModel.DataAnnotations;

namespace ProjetWebFinale.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Courriel { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Nom { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer votre mot de passe.")]
        [Compare("MotDePasse", ErrorMessage = "Votre nouveau mot de passe et sa confirmation ne sont pas équivalents.")]
        public string ConfirmerMotDePasse { get; set; }

        public char TypeUtilisateur { get; set; }
    }
}

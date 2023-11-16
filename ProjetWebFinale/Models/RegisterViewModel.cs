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
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("MotDePasse", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmerMotDePasse { get; set; }
    }
}

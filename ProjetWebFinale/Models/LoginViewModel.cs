﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetWebFinale.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Courriel { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }
        [Display(Name = "Se souvenir de moi")]
        public bool SeSouvenirDeMoi { get; set; }
    }
}

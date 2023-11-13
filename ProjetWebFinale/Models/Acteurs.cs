﻿using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class Acteurs
    {
        public int Id { get; set; }
        
        public string Nom { get; set; }

        public char Sexe { get; set; }
        public virtual ICollection<FilmsActeurs>? FilmsActeurs { get; set; }


    }
}
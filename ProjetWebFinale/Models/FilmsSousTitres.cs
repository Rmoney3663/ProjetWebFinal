﻿using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class FilmsSousTitres
    {
        public int Id { get; set; }
        public int NoSousTitre { get; set; }
        public virtual Films? Films { get; set; }

        public virtual SousTitres? SousTitres { get; set; }
    }
}
﻿using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class Supplements
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<FilmsSupplements>? FilmsSupplements { get; set; }

    }
}
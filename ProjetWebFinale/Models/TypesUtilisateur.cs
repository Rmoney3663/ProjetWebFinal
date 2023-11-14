﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class TypesUtilisateur
    {
        public char Id { get; set; }
        public string Description { get; set; }
        [InverseProperty("TypesUtilisateur")]
        public virtual ICollection<Utilisateurs>? Utilisateurs { get; set; }
    }
}

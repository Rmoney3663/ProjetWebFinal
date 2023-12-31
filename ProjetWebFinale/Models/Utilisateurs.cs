﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class Utilisateurs: IdentityUser<int>
    {
        public override int Id { get; set; }
        public string NomUtilisateur { get; set; }
        public string Courriel { get; set; }
        public int MotPasse { get; set; }
        public int TypeUtilisateur { get; set; }
        [ForeignKey("TypeUtilisateur")]
        [InverseProperty("Utilisateurs")]
        public virtual TypesUtilisateur? TypesUtilisateur { get; set; }
        [InverseProperty("Utilisateurs")]
        public virtual ICollection<Films>? Films { get; set; }
        /*[InverseProperty("Utilisateurs")]
        public virtual ICollection<Exemplaires>? Exemplaires { get; set; }*/
        [InverseProperty("Utilisateurs")]
        public virtual ICollection<EmpruntsFilms>? EmpruntsFilms { get; set; }
        [InverseProperty("Utilisateurs")]
        public virtual ICollection<UtilisateursPreferences>? UtilisateursPreferences { get; set; }
        [InverseProperty("UtilisateurProprietaire")]
        public virtual ICollection<Films>? FilmProprietaire { get; set; }

    }
}

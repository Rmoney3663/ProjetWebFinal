using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class UtilisateursPreferences
    {
        public int NoUtilisateur { get; set; }
        public int NoPreference { get; set; }
        public string? Valeur { get; set; }
        [ForeignKey("NoUtilisateur")]
        [InverseProperty("UtilisateursPreferences")]
        public virtual Utilisateurs? Utilisateurs { get; set; }
       /* [ForeignKey("NoPreference")]
        [InverseProperty("UtilisateursPreferences")]
        public virtual ValeursPreferences? ValeursPreferences { get; set; }*/
        [ForeignKey("NoPreference")]
        [InverseProperty("UtilisateursPreferences")]
        public virtual Preferences? Preferences { get; set; }
    }
}

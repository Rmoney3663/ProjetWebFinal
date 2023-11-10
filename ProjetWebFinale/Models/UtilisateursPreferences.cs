using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class UtilisateursPreferences
    {
        public int NoUtilisateur { get; set; }
        public int NoPreference { get; set; }
        public virtual Utilisateurs? Utilisateurs { get; set; }
        public virtual ValeursPreferences? ValeursPreferences { get; set; }
        public virtual Preferences? Preferences { get; set; }
    }
}

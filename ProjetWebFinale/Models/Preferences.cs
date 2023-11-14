using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class Preferences
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [InverseProperty("Preferences")]
        public virtual ICollection<UtilisateursPreferences>? UtilisateursPreferences { get; set; }
    }
}

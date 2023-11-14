using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class ValeursPreferences
    {
        public int Id { get; set; }
        public int NoPreference { get; set; }
        public string Valeur { get; set; }
    }
}

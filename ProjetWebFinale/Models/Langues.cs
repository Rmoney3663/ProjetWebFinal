using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class Langues
    {
        public int Id { get; set; }
        public string Langue { get; set; }
        [InverseProperty("Langues")]
        public virtual ICollection<FilmsLangues>? FilmsLangues { get; set; }
    }
}

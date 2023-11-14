using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class Supplements
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [InverseProperty("Supplements")]
        public virtual ICollection<FilmsSupplements>? FilmsSupplements { get; set; }

    }
}

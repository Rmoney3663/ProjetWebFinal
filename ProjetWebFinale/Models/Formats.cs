using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class Formats
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [InverseProperty("Formats")]
        public virtual ICollection<Films>? Films { get; set; }
    }
}

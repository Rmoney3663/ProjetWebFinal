using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class Categories
    {
        public int Id { get; set; }
       
        public string Description { get; set; }
        [InverseProperty("Categories")]
        public virtual ICollection<Films>? Films { get; set; }
    }
}

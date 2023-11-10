using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class Categories
    {
        public int NoCategorie { get; set; }
       
        public string Description { get; set; } 
        public virtual ICollection<Films>? Films { get; set; }
    }
}

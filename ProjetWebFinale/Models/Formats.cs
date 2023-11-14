using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class Formats
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Films>? Films { get; set; }
    }
}

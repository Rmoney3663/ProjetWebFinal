using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class FilmsSupplements
    {
        public int Id { get; set; }
        public int NoSupplement { get; set; }
        public virtual Films? Films { get; set; }
        public virtual Supplements? Supplements { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace ProjetWebFinale.Models
{
    public class FilmsLangues
    {
        public int Id { get; set; }
        public int NoLangue { get; set; }
        public virtual Films? Films { get; set; }
        public virtual Langues? Langues { get; set; }

    }
}

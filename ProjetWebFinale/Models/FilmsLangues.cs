using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class FilmsLangues
    {
        public int NoFilm { get; set; }
        public int NoLangue { get; set; }
        [ForeignKey("NoFilm")]
        [InverseProperty("FilmsLangues")]
        public virtual Films? Films { get; set; }
        [ForeignKey("NoLangue")]
        [InverseProperty("FilmsLangues")]
        public virtual Langues? Langues { get; set; }

    }
}

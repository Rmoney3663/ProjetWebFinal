using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class FilmsSupplements
    {
        public int NoFilm { get; set; }
        public int NoSupplement { get; set; }
        [ForeignKey("NoFilm")]
        [InverseProperty("FilmsSupplements")]
        public virtual Films? Films { get; set; }
        [ForeignKey("NoSupplement")]
        [InverseProperty("FilmsSupplements")]
        public virtual Supplements? Supplements { get; set; }
    }
}

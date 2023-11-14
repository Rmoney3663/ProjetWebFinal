using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebFinale.Models
{
    public class EmpruntsFilms
    {
        public int NoFilm { get; set; }
        public int NoUtilisateur { get; set; }       
        public DateTime DateEmprunt { get; set; }
       

        [ForeignKey("NoUtilisateur")]
        [InverseProperty("EmpruntsFilms")]
        public virtual Utilisateurs? Utilisateurs { get; set; }

        [ForeignKey("NoFilm")]
        [InverseProperty("EmpruntsFilms")]
        public virtual Films? Films { get; set; }
    }
}

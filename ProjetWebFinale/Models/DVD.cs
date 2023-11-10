using System.ComponentModel.DataAnnotations;

namespace ProjetWebFinale.Models
{
    public class DVD
    {
        public int Id { get; set; }
       
        public DateTime AnneSortie { get; set; }
        
    
        public virtual Categorie? Categorie
        {
            get; set;

        }
    }
}

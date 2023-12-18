using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjetWebFinale.Models
{
    public class Courriel
    {
        public IEnumerable<string> Receivers { get; set; }
        public IEnumerable<SelectListItem> Emails { get; set; }
    }
}

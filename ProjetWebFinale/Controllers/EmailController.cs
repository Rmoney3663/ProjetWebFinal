using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetWebFinale.Models;

namespace ProjetWebFinale.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        private readonly FilmDbContext _context;

        public EmailController(FilmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Email()
        {
            //var utilisateurs = _context.Utilisateurs.ToList();
            var utilisateur = from u in _context.Utilisateurs where u.TypeUtilisateur == 3 select u;

            ViewData["Courriel"] = new SelectList(utilisateur, "Courriel", "Courriel");

            return View();
        }




    }
}

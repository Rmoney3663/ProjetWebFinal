using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;
using ProjetWebFinale.Models;

namespace ProjetWebFinale.Controllers
{
    [Authorize]
    public class FilmsUtilisateursController : Controller
    {
        private readonly FilmDbContext _context;

        public FilmsUtilisateursController(FilmDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Email(string courrielRecipient, string message, string utilisateur)
        {
            var listeCourriels = new List<MimeMessage>();

            if (courrielRecipient == null)
            {
                //Appropriation du DVD
                var courrielsUtilisateurs = (from p in _context.UtilisateursPreferences where p.NoPreference == 4 select p.Utilisateurs.Courriel).ToList();

                foreach (var courriel in courrielsUtilisateurs)
                {
                    var email = new MimeMessage();
                    email.From.Add(new MailboxAddress("Sender test", "w56projet3equipe4@gmail.com"));

                    //Email adress in DB might be used -> Temporary email
                    email.To.Add(new MailboxAddress("Receiver test", "jiyoh32722@mainoj.com"));

                    email.Subject = "Avis d'appropriation";
                    email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        Text = "Un utilisateur désire s'approprier ce DVD."
                    };

                    listeCourriels.Add(email);
                }
            }
            else
            {
                //Envoyez un courriel à l'utilisateur
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Sender test", "w56projet3equipe4@gmail.com"));

                //Email adress in DB might be used -> Temporary email
                email.To.Add(new MailboxAddress("Receiver test", "jiyoh32722@mainoj.com")); 

                email.Subject = "Testing out email sending";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "<b>"+ message +"</b>"
                };

                listeCourriels.Add(email);
            }
            
            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 465, true);
                smtp.Authenticate("w56projet3equipe4@gmail.com", "gxlb tpuz batz zuun ");

                //Envoie un email à chaque utilisateur
                foreach (MimeMessage email in listeCourriels)
                {
                    smtp.Send(email);
                }
                
                smtp.Disconnect(true);
            }
            return RedirectToAction("Index", new { name = utilisateur });
        }

        // GET: FilmsUtilisateurs
        public async Task<IActionResult> Index(string name, string searchString)
        {
            if (_context.Films == null)
            {
                return NotFound();
            }

            var films = from f in _context.Films where f.UtilisateurProprietaire.NomUtilisateur == name select f;
            films.Include(f => f.UtilisateurProprietaire).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                films = films.Where(s => s.TitreFrancais!.Contains(searchString) || s.TitreOriginal!.Contains(searchString));
            }

            return View(await films.ToListAsync());
        }

        // GET: FilmsUtilisateurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var films = await _context.Films
                .Include(f => f.Categories)
                .Include(f => f.Formats)
                .Include(f => f.Producteurs)
                .Include(f => f.Realisateurs)
                .Include(f => f.UtilisateurProprietaire)
                .Include(f => f.Utilisateurs)
                .Include(f => f.FilmsSousTitres).ThenInclude(f => f.SousTitres)
                .Include(f => f.FilmsLangues).ThenInclude(f => f.Langues)
                .Include(f => f.FilmsSupplements).ThenInclude(f => f.Supplements)
                .Include(f => f.EmpruntsFilms).ThenInclude(f => f.Utilisateurs)
                .Include(f => f.FilmsActeurs).ThenInclude(f => f.Acteurs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (films == null)
            {
                return NotFound();
            }

            return View(films);
        }

        
    }
}

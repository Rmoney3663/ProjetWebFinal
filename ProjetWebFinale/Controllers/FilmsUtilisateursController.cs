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

        [HttpGet]
        public IActionResult Email()
        {
            return View();
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
                    email.To.Add(new MailboxAddress("Receiver test", courriel));

                    email.Subject = "Avis d'appropriation";
                    email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        //Potential HTML injection
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (films == null)
            {
                return NotFound();
            }

            return View(films);
        }

        // GET: FilmsUtilisateurs/Create
        public IActionResult Create()
        {
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Categories, "Id", "Id");
            ViewData["Format"] = new SelectList(_context.Formats, "Id", "Id");
            ViewData["NoProducteur"] = new SelectList(_context.Producteurs, "Id", "Id");
            ViewData["NoRealisateur"] = new SelectList(_context.Realisateurs, "Id", "Id");
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Utilisateurs, "Id", "Id");
            ViewData["NoUtilisateurMAJ"] = new SelectList(_context.Utilisateurs, "Id", "Id");
            return View();
        }

        // POST: FilmsUtilisateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnneeSortie,Categorie,Format,DateMAJ,NoUtilisateurMAJ,Resume,DureeMinutes,FilmOriginal,ImagePochette,NbDisques,TitreFrancais,TitreOriginal,VersionEtendue,NoRealisateur,NoProducteur,Xtra,NoUtilisateurProprietaire")] Films films)
        {
            if (ModelState.IsValid)
            {
                _context.Add(films);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Categories, "Id", "Id", films.NoUtilisateurProprietaire);
            ViewData["Format"] = new SelectList(_context.Formats, "Id", "Id", films.Format);
            ViewData["NoProducteur"] = new SelectList(_context.Producteurs, "Id", "Id", films.NoProducteur);
            ViewData["NoRealisateur"] = new SelectList(_context.Realisateurs, "Id", "Id", films.NoRealisateur);
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Utilisateurs, "Id", "Id", films.NoUtilisateurProprietaire);
            ViewData["NoUtilisateurMAJ"] = new SelectList(_context.Utilisateurs, "Id", "Id", films.NoUtilisateurMAJ);
            return View(films);
        }

        // GET: FilmsUtilisateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var films = await _context.Films.FindAsync(id);
            if (films == null)
            {
                return NotFound();
            }
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Categories, "Id", "Id", films.NoUtilisateurProprietaire);
            ViewData["Format"] = new SelectList(_context.Formats, "Id", "Id", films.Format);
            ViewData["NoProducteur"] = new SelectList(_context.Producteurs, "Id", "Id", films.NoProducteur);
            ViewData["NoRealisateur"] = new SelectList(_context.Realisateurs, "Id", "Id", films.NoRealisateur);
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Utilisateurs, "Id", "Id", films.NoUtilisateurProprietaire);
            ViewData["NoUtilisateurMAJ"] = new SelectList(_context.Utilisateurs, "Id", "Id", films.NoUtilisateurMAJ);
            return View(films);
        }

        // POST: FilmsUtilisateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnneeSortie,Categorie,Format,DateMAJ,NoUtilisateurMAJ,Resume,DureeMinutes,FilmOriginal,ImagePochette,NbDisques,TitreFrancais,TitreOriginal,VersionEtendue,NoRealisateur,NoProducteur,Xtra,NoUtilisateurProprietaire")] Films films)
        {
            if (id != films.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(films);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmsExists(films.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Categories, "Id", "Id", films.NoUtilisateurProprietaire);
            ViewData["Format"] = new SelectList(_context.Formats, "Id", "Id", films.Format);
            ViewData["NoProducteur"] = new SelectList(_context.Producteurs, "Id", "Id", films.NoProducteur);
            ViewData["NoRealisateur"] = new SelectList(_context.Realisateurs, "Id", "Id", films.NoRealisateur);
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Utilisateurs, "Id", "Id", films.NoUtilisateurProprietaire);
            ViewData["NoUtilisateurMAJ"] = new SelectList(_context.Utilisateurs, "Id", "Id", films.NoUtilisateurMAJ);
            return View(films);
        }

        // GET: FilmsUtilisateurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (films == null)
            {
                return NotFound();
            }

            return View(films);
        }

        // POST: FilmsUtilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Films == null)
            {
                return Problem("Entity set 'FilmDbContext.Films'  is null.");
            }
            var films = await _context.Films.FindAsync(id);
            if (films != null)
            {
                _context.Films.Remove(films);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmsExists(int id)
        {
          return (_context.Films?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

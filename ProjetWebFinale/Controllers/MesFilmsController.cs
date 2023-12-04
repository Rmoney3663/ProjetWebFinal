using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetWebFinale.Models;

namespace ProjetWebFinale.Controllers
{
    public class MesFilmsController : Controller
    {
        private readonly FilmDbContext _context;
        private readonly UserManager<Utilisateurs> _userManager;
        public MesFilmsController(FilmDbContext context, UserManager<Utilisateurs> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MesFilms
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Films == null)
            {
                return NotFound();
            }


            var films = from f in _context.Films where f.UtilisateurProprietaire.NomUtilisateur == User.Identity.Name select f;
            films.Include(f => f.UtilisateurProprietaire).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                films = films.Where(s => s.TitreFrancais!.Contains(searchString) || s.TitreOriginal!.Contains(searchString));
            }

            return View(await films.ToListAsync());
        }

        // GET: MesFilms/Details/5
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

        // GET: MesFilms/Create
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

        // POST: MesFilms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnneeSortie,Categorie,Format,DateMAJ,NoUtilisateurMAJ,Resume,DureeMinutes,FilmOriginal,ImagePochette,NbDisques,TitreFrancais,TitreOriginal,VersionEtendue,NoRealisateur,NoProducteur,Xtra,NoUtilisateurProprietaire")] Films films, IFormFile file)
        {
            var user = await _userManager.GetUserAsync(User);
            films.NoUtilisateurMAJ = user.Id;
            films.DateMAJ = DateTime.Now;
            Console.WriteLine(file.FileName);
            Console.WriteLine($"User Id: {user?.Id}, User Name: {user?.UserName}");
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("ImagePochette", "Veuillez sélectionner une image pour l'affiche du film.");
            }

            foreach (var m in ModelState)
            {
                foreach (var er in m.Value.Errors)
                {
                    Console.WriteLine(m.Key);
                    Console.WriteLine(er.ErrorMessage);
                }
            }
            if (ModelState.IsValid)
            {
                var tempFilename = "temp_filename";
                string extension = Path.GetExtension(file.FileName);
                string tempFilePath = Path.Combine("wwwroot/liste-vignettes", tempFilename + extension);
                using (Stream fileStream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                _context.Add(films);
                await _context.SaveChangesAsync();

                var generatedId = films.Id;

                var finalFilename = $"{generatedId}{extension}";
                var finalFilePath = Path.Combine("wwwroot/liste-vignettes", finalFilename);
                System.IO.File.Move(tempFilePath, finalFilePath);
                var finalnameimage = generatedId - 50000;
                films.ImagePochette = finalnameimage + extension;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Utilisateurs, "Id", "NomUtilisateur", films.NoUtilisateurProprietaire);
            ViewData["Format"] = new SelectList(_context.Formats, "Id", "Description", films.Format);
            ViewData["NoProducteur"] = new SelectList(_context.Producteurs, "Id", "Nom", films.NoProducteur);
            ViewData["NoRealisateur"] = new SelectList(_context.Realisateurs, "Id", "Nom", films.NoRealisateur);
            ViewData["Categorie"] = new SelectList(_context.Categories, "Id", "Description", films.Categorie);
            return View(films);
        }

        // GET: MesFilms/Edit/5
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
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Utilisateurs, "Id", "NomUtilisateur", films.NoUtilisateurProprietaire);
            ViewData["Format"] = new SelectList(_context.Formats, "Id", "Description", films.Format);
            ViewData["NoProducteur"] = new SelectList(_context.Producteurs, "Id", "Nom", films.NoProducteur);
            ViewData["NoRealisateur"] = new SelectList(_context.Realisateurs, "Id", "Nom", films.NoRealisateur);
            ViewData["Categorie"] = new SelectList(_context.Categories, "Id", "Description", films.Categorie);
            return View(films);
        }

        // POST: MesFilms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnneeSortie,Categorie,Format,DateMAJ,NoUtilisateurMAJ,Resume,DureeMinutes,FilmOriginal,ImagePochette,NbDisques,TitreFrancais,TitreOriginal,VersionEtendue,NoRealisateur,NoProducteur,Xtra,NoUtilisateurProprietaire")] Films films, IFormFile? file)
        {
            if (id != films.Id)
            {
                return NotFound();
            }
            foreach (var m in ModelState)
            {
                foreach (var er in m.Value.Errors)
                {
                    Console.WriteLine(m.Key);
                    Console.WriteLine(er.ErrorMessage);
                }
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                films.NoUtilisateurMAJ = user.Id;
                films.DateMAJ = DateTime.Now;
                try
                {
                    if (file != null && file.Length > 0)
                    {
                        System.IO.File.Delete("wwwroot/liste-vignettes" + films.Id + ".jpg");

                        string extension = Path.GetExtension(file.FileName);
                        string tempFilePath = Path.Combine("wwwroot/liste-vignettes", films.Id + extension);
                        using (Stream fileStream = new FileStream(tempFilePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }

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
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Utilisateurs, "Id", "NomUtilisateur", films.NoUtilisateurProprietaire);
            ViewData["Format"] = new SelectList(_context.Formats, "Id", "Description", films.Format);
            ViewData["NoProducteur"] = new SelectList(_context.Producteurs, "Id", "Nom", films.NoProducteur);
            ViewData["NoRealisateur"] = new SelectList(_context.Realisateurs, "Id", "Nom", films.NoRealisateur);
            ViewData["Categorie"] = new SelectList(_context.Categories, "Id", "Description", films.Categorie);
            return View(films);
        }

        // GET: MesFilms/Delete/5
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

        // POST: MesFilms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var films = await _context.Films.FindAsync(id);

                if (films != null)
                {
                    _context.Films.Remove(films);
                    await _context.SaveChangesAsync();

                    var filePath = Path.Combine("wwwroot/liste-vignettes", id + ".jpg");

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Films");
            }
        }

        private bool FilmsExists(int id)
        {
          return (_context.Films?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

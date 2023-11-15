using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetWebFinale.Models;

namespace ProjetWebFinale
{
    public class FilmsController : Controller
    {
        private readonly FilmDbContext _context;

        public FilmsController(FilmDbContext context)
        {
            _context = context;
        }

        // GET: Films
        public async Task<IActionResult> Index()
        {
            var filmDbContext = _context.Films.Include(f => f.Categories).Include(f => f.Formats).Include(f => f.Producteurs).Include(f => f.Realisateurs).Include(f => f.UtilisateurProprietaire).Include(f => f.Utilisateurs);
            return View(await filmDbContext.ToListAsync());
        }

        // GET: Films/Details/5
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

        // GET: Films/Create
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

        // POST: Films/Create
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

        // GET: Films/Edit/5
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

        // POST: Films/Edit/5
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

        // GET: Films/Delete/5
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

        // POST: Films/Delete/5
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

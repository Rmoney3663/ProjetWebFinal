using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetWebFinale.Models;

namespace ProjetWebFinale.Controllers
{
    [Authorize]
    public class FilmsController : Controller
    {
        private readonly FilmDbContext _context;
        private readonly UserManager<Utilisateurs> _userManager;
        public FilmsController(FilmDbContext context, UserManager<Utilisateurs> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Films
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Films == null)
            {
                return NotFound();
            }

            var films = from f in _context.Films select f;
            films.Include(f => f.UtilisateurProprietaire).ToList();


            if (!String.IsNullOrEmpty(searchString))
            {
                films = films.Where(s => s.TitreFrancais!.Contains(searchString) || s.TitreOriginal!.Contains(searchString));
            }


            return View(await films.ToListAsync());
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
                .Include(f => f.FilmsActeurs)
                    .ThenInclude(fa => fa.Acteurs)
                .Include(f => f.FilmsLangues)
                    .ThenInclude(fa => fa.Langues)
                .Include(f => f.FilmsSousTitres)
                    .ThenInclude(fa => fa.SousTitres)
                .Include(f => f.FilmsSupplements)
                    .ThenInclude(fa => fa.Supplements)
                .Include(f => f.EmpruntsFilms)
                    .ThenInclude(fa => fa.Utilisateurs)
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
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Utilisateurs, "Id", "NomUtilisateur");
            ViewData["Format"] = new SelectList(_context.Formats, "Id", "Description");
            ViewData["NoProducteur"] = new SelectList(_context.Producteurs, "Id", "Nom");
            ViewData["NoRealisateur"] = new SelectList(_context.Realisateurs, "Id", "Nom");
            ViewData["NoUtilisateurMAJ"] = new SelectList(_context.Utilisateurs, "Id", "NomUtilisateur");
            ViewData["Categorie"] = new SelectList(_context.Categories, "Id", "Description");

            ViewBag.Langues = new SelectList(_context.FilmsLangues.Include(fl => fl.Langues).Select(fl => fl.Langues).Distinct().ToList(), "Id", "Langue");



            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnneeSortie,Categorie,Format,NoUtilisateurMAJ,Resume,DureeMinutes,FilmOriginal,NbDisques,TitreFrancais,TitreOriginal,VersionEtendue,NoRealisateur,NoProducteur,Xtra,NoUtilisateurProprietaire")] Films films, IFormFile file, List<int> selectedLangues)
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
                foreach(var er in m.Value.Errors)
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

                if (selectedLangues != null)
                {
                    if (films.FilmsLangues == null)
                    {
                        films.FilmsLangues = new List<FilmsLangues>();
                    }
                    foreach (var langId in selectedLangues)
                    {
                        films.FilmsLangues.Add(new FilmsLangues { NoFilm = films.Id, NoLangue = langId });
                    }
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Utilisateurs, "Id", "NomUtilisateur", films.NoUtilisateurProprietaire);
            ViewData["Format"] = new SelectList(_context.Formats, "Id", "Description", films.Format);
            ViewData["NoProducteur"] = new SelectList(_context.Producteurs, "Id", "Nom", films.NoProducteur);
            ViewData["NoRealisateur"] = new SelectList(_context.Realisateurs, "Id", "Nom", films.NoRealisateur);
            ViewData["Categorie"] = new SelectList(_context.Categories, "Id", "Description", films.Categorie);
            ViewBag.Langues = new SelectList(_context.FilmsLangues.Include(fl => fl.Langues).Select(fl => fl.Langues).Distinct().ToList(), "Id", "Langue");


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
            ViewData["NoUtilisateurProprietaire"] = new SelectList(_context.Utilisateurs, "Id", "NomUtilisateur", films.NoUtilisateurProprietaire);
            ViewData["Format"] = new SelectList(_context.Formats, "Id", "Description", films.Format);
            ViewData["NoProducteur"] = new SelectList(_context.Producteurs, "Id", "Nom", films.NoProducteur);
            ViewData["NoRealisateur"] = new SelectList(_context.Realisateurs, "Id", "Nom", films.NoRealisateur);
            ViewData["Categorie"] = new SelectList(_context.Categories, "Id", "Description", films.Categorie);

            var availableLangues = _context.Langues.ToList();

            var selectedLangueIds = _context.FilmsLangues
                .Where(fl => fl.NoFilm == id)
                .Select(fl => fl.NoLangue)
                .ToList();

            ViewBag.Langues = new SelectList(availableLangues, "Id", "Langue");
            ViewBag.SelectedLangues = selectedLangueIds;


            return View(films);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnneeSortie,Categorie,Format,Resume,DureeMinutes,FilmOriginal,NbDisques,TitreFrancais,TitreOriginal,VersionEtendue,NoRealisateur,NoProducteur,Xtra,NoUtilisateurProprietaire")] Films films, IFormFile? file, List<int> selectedLangueIds)
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
                var existingLangues = _context.FilmsLangues
                    .Where(fl => fl.NoFilm == id)
                    .ToList();
                Console.WriteLine("SelectedLangueIds: " + string.Join(", ", selectedLangueIds));
                Console.WriteLine("ExistingLangues: " + string.Join(", ", existingLangues.Select(fl => fl.NoLangue)));

                // Remove existing associations that are not selected
                var removedLangues = existingLangues
                    .Where(fl => !selectedLangueIds.Contains(fl.NoLangue))
                    .ToList();

                if (removedLangues.Any())
                {
                    _context.FilmsLangues.RemoveRange(removedLangues);
                }

                // Add new associations
                var newLangues = selectedLangueIds
                    .Where(langueId => !existingLangues.Any(fl => fl.NoLangue == langueId))
                    .Select(langueId => new FilmsLangues { NoFilm = id, NoLangue = langueId })
                    .ToList();

                _context.FilmsLangues.AddRange(newLangues);

                // Save changes to the database
                await _context.SaveChangesAsync();


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

            var availableLangues = _context.Langues.ToList();

            var selectedLangueIds2 = _context.FilmsLangues
                .Where(fl => fl.NoFilm == id)
                .Select(fl => fl.NoLangue)
                .ToList();

            ViewBag.Langues = new SelectList(availableLangues, "Id", "Langue");
            ViewBag.SelectedLangues = selectedLangueIds2;

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

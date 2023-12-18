using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetWebFinale.Models;

namespace ProjetWebFinale.Controllers
{
    public class AjoutUtilisateurController : Controller
    {
        private readonly SignInManager<Utilisateurs>
    signInManager;
        private readonly FilmDbContext _context;
        private readonly UserManager<Utilisateurs> userManager;
        public AjoutUtilisateurController(FilmDbContext context, UserManager<Utilisateurs>
            userManager, SignInManager<Utilisateurs>
                signInManager)
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: AjoutUtilisateur
        public async Task<IActionResult>
            Index()
        {
            var filmDbContext = _context.Utilisateurs.Include(u => u.TypesUtilisateur);
            return View(await filmDbContext.ToListAsync());
        }

        // GET: AjoutUtilisateur/Details/5
        public async Task<IActionResult>
            Details(int? id)
        {
            if (id == null || _context.Utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateurs = await _context.Utilisateurs
            .Include(u => u.TypesUtilisateur)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (utilisateurs == null)
            {
                return NotFound();
            }

            return View(utilisateurs);
        }

        // GET: AjoutUtilisateur/Create
        public IActionResult Create()
        {
            IEnumerable<TypesUtilisateur>
                liste = _context.TypesUtilisateur.Except(_context.TypesUtilisateur.Where(u => u.Identifiant == 'A'));
            ViewData["TypeUtilisateur"] = new SelectList(liste, "Identifiant", "Description");
            return View();
        }

        // POST: AjoutUtilisateur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
            Create([Bind("Nom,Courriel,MotDePasse,ConfirmerMotDePasse,TypeUtilisateur")] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var noType = 100;
                if (model.TypeUtilisateur == 'S')
                    noType = 2;
                else if (model.TypeUtilisateur == 'U')
                    noType = 3;
                var user = new Utilisateurs
                {
                    UserName = model.Nom,
                    Email = model.Courriel,
                    Courriel = model.Courriel,
                    NomUtilisateur = model.Nom,
                    TypeUtilisateur = noType,
                    EmailConfirmed = true
                };
                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.MotDePasse);
                // If user is successfully created, sign-in the user using. SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    //Sets default preferences on first login
                    var pref1 = new UtilisateursPreferences
                    {
                        NoUtilisateur = user.Id,
                        NoPreference = 3,
                        Valeur = "oui"
                    };

                    var pref2 = new UtilisateursPreferences
                    {
                        NoUtilisateur = user.Id,
                        NoPreference = 4,
                        Valeur = "oui"
                    };

                    var pref3 = new UtilisateursPreferences
                    {
                        NoUtilisateur = user.Id,
                        NoPreference = 5,
                        Valeur = "oui"
                    };

                    var pref4 = new UtilisateursPreferences
                    {
                        NoUtilisateur = user.Id,
                        NoPreference = 7,
                        Valeur = "12"
                    };
                    _context.UtilisateursPreferences.Add(pref1);
                    _context.UtilisateursPreferences.Add(pref2);
                    _context.UtilisateursPreferences.Add(pref3);
                    _context.UtilisateursPreferences.Add(pref4);
                    await _context.SaveChangesAsync();

                    await signInManager.SignOutAsync();

                    return RedirectToAction("Login", "Account");
                }
                // If there are any errors, add them to the ModelState object. which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            IEnumerable<TypesUtilisateur>
                liste = _context.TypesUtilisateur.Except(_context.TypesUtilisateur.Where(u => u.Identifiant == 'A'));
            ViewData["TypeUtilisateur"] = new SelectList(liste, "Identifiant", "Description");
            return View(model);
        }

        // GET: AjoutUtilisateur/Edit/5
        public async Task<IActionResult>
            Edit(int? id)
        {
            if (id == null || _context.Utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateurs = await _context.Utilisateurs.FindAsync(id);
            if (utilisateurs == null)
            {
                return NotFound();
            }
            ViewData["TypeUtilisateur"] = new SelectList(_context.TypesUtilisateur, "Id", "Id", utilisateurs.TypeUtilisateur);
            return View(utilisateurs);
        }

        // POST: AjoutUtilisateur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
            Edit(int id, [Bind("Id,NomUtilisateur,Courriel,MotPasse,TypeUtilisateur,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Utilisateurs utilisateurs)
        {
            if (id != utilisateurs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateurs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilisateursExists(utilisateurs.Id))
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
            ViewData["TypeUtilisateur"] = new SelectList(_context.TypesUtilisateur, "Id", "Id", utilisateurs.TypeUtilisateur);
            return View(utilisateurs);
        }

        // GET: AjoutUtilisateur/Delete/5
        public async Task<IActionResult>
            Delete(int? id)
        {
            if (id == null || _context.Utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateurs = await _context.Utilisateurs
            .Include(u => u.TypesUtilisateur)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (utilisateurs == null)
            {
                return NotFound();
            }

            return View(utilisateurs);
        }

        // POST: AjoutUtilisateur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
            DeleteConfirmed(int id)
        {
            if (_context.Utilisateurs == null)
            {
                return Problem("Entity set 'FilmDbContext.Utilisateurs'  is null.");
            }
            var utilisateurs = await _context.Utilisateurs.FindAsync(id);
            if (utilisateurs != null)
            {
                _context.Utilisateurs.Remove(utilisateurs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateursExists(int id)
        {
            return (_context.Utilisateurs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetWebFinale.Models;

namespace ProjetWebFinale.Controllers
{
    public class AjoutUtilisateurController : Controller
    {
        private readonly FilmDbContext _context;

        public AjoutUtilisateurController(FilmDbContext context)
        {
            _context = context;
        }

        // GET: AjoutUtilisateur
        public async Task<IActionResult> Index()
        {
            var filmDbContext = _context.Utilisateurs.Include(u => u.TypesUtilisateur);
            return View(await filmDbContext.ToListAsync());
        }

        // GET: AjoutUtilisateur/Details/5
        public async Task<IActionResult> Details(int? id)
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
            ViewData["TypeUtilisateur"] = new SelectList(_context.TypesUtilisateur, "Identifiant", "Description");
            return View();
        }

        // POST: AjoutUtilisateur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomUtilisateur,Courriel,MotPasse,TypeUtilisateur,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Utilisateurs utilisateurs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilisateurs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeUtilisateur"] = new SelectList(_context.TypesUtilisateur, "Identifiant", "Description", utilisateurs.TypeUtilisateur);
            return View(utilisateurs);
        }

        // GET: AjoutUtilisateur/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomUtilisateur,Courriel,MotPasse,TypeUtilisateur,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Utilisateurs utilisateurs)
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
        public async Task<IActionResult> Delete(int? id)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
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

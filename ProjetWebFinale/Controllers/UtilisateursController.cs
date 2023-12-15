using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetWebFinale.Models;
using Microsoft.AspNetCore.Identity;

namespace ProjetWebFinale.Controllers
{
    [Authorize]
    public class UtilisateursController : Controller
    {
        private readonly FilmDbContext _context;
        private readonly UserManager<Utilisateurs> _userManager;
        public UtilisateursController(FilmDbContext context, UserManager<Utilisateurs> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Utilisateurs
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var currentUserId = user.Id;

            //Get all non-admin users and exclude the currently logged in user.
            var utilisateur = from u in _context.Utilisateurs where u.TypeUtilisateur != 1 && u.Id != currentUserId select u;
            utilisateur.Include(t => t.TypesUtilisateur).ToList();

            return View(await utilisateur.ToListAsync());
        }

        // GET: Utilisateurs/Details/5
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

        //Probably remove the "create" part here
        // GET: Utilisateurs/Create
        public IActionResult Create()
        {
            ViewData["TypeUtilisateur"] = new SelectList(_context.TypesUtilisateur, "Id", "Id");
            return View();
        }

        // POST: Utilisateurs/Create
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
            ViewData["TypeUtilisateur"] = new SelectList(_context.TypesUtilisateur, "Id", "Id", utilisateurs.TypeUtilisateur);
            return View(utilisateurs);
        }

        //Edit current user preferences 
        // GET: Utilisateurs/Edit/5
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

        // POST: Utilisateurs/Edit/5
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

        //Probably remove this part
        // GET: Utilisateurs/Delete/5
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

        // POST: Utilisateurs/Delete/5
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

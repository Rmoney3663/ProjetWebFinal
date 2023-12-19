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
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetWebFinale.Models;

namespace ProjetWebFinale.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<Utilisateurs> _userManager;
        private readonly SignInManager<Utilisateurs> _signInManager;
        private readonly FilmDbContext _context;

        public ProfileController(FilmDbContext context, UserManager<Utilisateurs> userManager, SignInManager<Utilisateurs> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int? id)
        {
            var userToModify = await _userManager.FindByIdAsync(id.ToString());
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser.TypeUtilisateur != 3 && userToModify.Id != currentUser.Id)
            {
                //Shouldn't be here. Redirect to home.
                return RedirectToAction("Index", "Films");
            }
            else
            {
                var user = await _context.Utilisateurs
                .FirstOrDefaultAsync(m => m.Id == id);
                return View(user);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Profile(string id, string motDePasseActuel, string? nouveauMotDePasse, string nom, string courriel)
        {
            Utilisateurs userToModify = await _userManager.FindByIdAsync(id);
            if (userToModify != null)
            {
                if (nouveauMotDePasse != null)
                {
                    //User wants to change its password
                    IdentityResult result = await _userManager.ChangePasswordAsync(userToModify, motDePasseActuel, nouveauMotDePasse);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(userToModify, isPersistent: false);
                        return RedirectToAction("Index", "Films");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Veuillez entrer votre mot de passe actuel");
                        return View(userToModify);
                    }
                }

                if (userToModify.NomUtilisateur != nom)
                {
                    //Admin wants to change name of user
                    userToModify.NomUtilisateur = nom;
                    userToModify.UserName = nom;
                    userToModify.NormalizedUserName = nom.ToUpper();
                }

                if (userToModify.Courriel != courriel)
                {
                    //Admin wants to change email of user
                    userToModify.Courriel = courriel;
                    userToModify.Email = courriel;
                    userToModify.NormalizedEmail = courriel.ToUpper();
                }
                _context.Update(userToModify);
                _context.SaveChanges();

            }
            return RedirectToAction("Index", "Films");
        }
    }
}

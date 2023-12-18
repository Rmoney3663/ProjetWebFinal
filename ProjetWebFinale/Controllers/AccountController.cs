using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetWebFinale.Models;

namespace ProjetWebFinale.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Utilisateurs> userManager;
        private readonly SignInManager<Utilisateurs> signInManager;
        private readonly FilmDbContext context;

        public AccountController(FilmDbContext context, UserManager<Utilisateurs> userManager, SignInManager<Utilisateurs> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new Utilisateurs
                {
                    UserName = model.Nom,
                    Email = model.Courriel,
                    Courriel = model.Courriel,
                    NomUtilisateur = model.Nom,
                    TypeUtilisateur = 3,
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
                    context.UtilisateursPreferences.Add(pref1);
                    context.UtilisateursPreferences.Add(pref2);
                    context.UtilisateursPreferences.Add(pref3);
                    context.UtilisateursPreferences.Add(pref4);
                    await context.SaveChangesAsync();


                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Films");
                }
                // If there are any errors, add them to the ModelState object. which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                model.NomUtilisateur, model.MotDePasse, model.SeSouvenirDeMoi, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Films");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}

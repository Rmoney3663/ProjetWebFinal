using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetWebFinale.Models;

namespace ProjetWebFinale.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Utilisateurs> userManager;
        private readonly SignInManager<Utilisateurs> signInManager;
        private readonly RoleManager<TypesUtilisateur> roleManager;

        public AccountController(UserManager<Utilisateurs> userManager, SignInManager<Utilisateurs> signInManager, RoleManager<TypesUtilisateur> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            bool a = await roleManager.RoleExistsAsync("1");
            bool s = await roleManager.RoleExistsAsync("2");
            bool u = await roleManager.RoleExistsAsync("3");
            var t = roleManager.Roles.ToList();

            if (!a)
            {
                var role = new TypesUtilisateur
                {
                    Description = "Administrateur",
                    Name = "1",
                    Identifiant = 'A'
                };
                await roleManager.CreateAsync(role);
            }

            if (!s)
            {
                var role = new TypesUtilisateur
                {
                    Description = "Superutilisateur",
                    Name = "2",
                    Identifiant = 'S'
                };
                await roleManager.CreateAsync(role);
            }

            if (!u)
            {
                var role = new TypesUtilisateur
                {
                    Description = "Utilisateur",
                    Name = "3",
                    Identifiant = 'U'
                };
                await roleManager.CreateAsync(role);
            }

            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new Utilisateurs
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Courriel = model.Email,
                    NomUtilisateur = model.Email,
                    TypeUtilisateur = 6,
                    EmailConfirmed = true,
                    
                };
                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);
                // If user is successfully created, sign-in the user using. SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "Employees");
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
                model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    //TODO: Redirect to correct page
                    return RedirectToAction("index", "Employees");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}

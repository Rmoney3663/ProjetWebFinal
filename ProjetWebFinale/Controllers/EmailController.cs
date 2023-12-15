using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetWebFinale.Models;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;

namespace ProjetWebFinale.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        private readonly FilmDbContext _context;
        private readonly UserManager<Utilisateurs> _userManager;

        public EmailController(FilmDbContext context, UserManager<Utilisateurs> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        [HttpGet]
        public async Task<IActionResult> Email()
        {
            var user = await _userManager.GetUserAsync(User);
            var currentUserId = user.Id;

            //Get all non-admin users and exclude the currently logged in user.
            var utilisateur = from u in _context.Utilisateurs where u.TypeUtilisateur != 1 && u.Id != currentUserId select u;
            ViewData["Courriel"] = new SelectList(utilisateur, "Courriel", "Courriel");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Email(string sender, string receiver, string message, string tout)
        {
            var user = await _userManager.GetUserAsync(User);
            var currentUserId = user.Id;
            var listeCourriels = new List<MimeMessage>();

            if (tout == "on")
            {
                //Send to all users
                var courriels = (from u in _context.Utilisateurs where u.TypeUtilisateur != 1 && u.Id != currentUserId select u.Courriel).ToList();
                foreach (string courriel in courriels)
                {
                    var email = new MimeMessage();
                    email.From.Add(new MailboxAddress(sender, sender));

                    //Email address in DB might be used -> Temporary email
                    email.To.Add(new MailboxAddress(courriel, courriel));

                    email.Subject = "Testing out email sending";
                    email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        Text = "<b>" + message + "</b>"
                    };

                    listeCourriels.Add(email);
                }
            }
            else
            {
                //Send to one user
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(sender, sender));

                //Email address in DB might be used -> Temporary email
                email.To.Add(new MailboxAddress(receiver, receiver));

                email.Subject = "Testing out email sending";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "<b>" + message + "</b>"
                };

                listeCourriels.Add(email);
            }

           

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 465, true);
                smtp.Authenticate("w56projet3equipe4@gmail.com", "gxlb tpuz batz zuun ");

                //Envoie un email à chaque utilisateur
                foreach (MimeMessage courriel in listeCourriels)
                {
                    smtp.Send(courriel);
                }
                smtp.Disconnect(true);
            }

            return RedirectToAction("Index", "Films");
        }
    }
}

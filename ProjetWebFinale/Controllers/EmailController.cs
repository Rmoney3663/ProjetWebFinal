using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetWebFinale.Models;
using MimeKit;

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
            List<SelectListItem> emailsSelectListItems = new List<SelectListItem>();

            //Get all non-admin users and exclude the currently logged in user.
            var courriels = (from u in _context.Utilisateurs where u.TypeUtilisateur != 1 && u.Id != currentUserId select u.Courriel).ToList();
            //ViewData["Courriel"] = new SelectList(utilisateur, "Courriel", "Courriel");
            foreach (string c in courriels)
            {
                SelectListItem selectList = new()
                {
                    Text = c,
                    Value = c,
                };
                emailsSelectListItems.Add(selectList);
            }

            Courriel courriel = new()
            {
                Emails = emailsSelectListItems
            };

            return View(courriel);
        }

        [HttpPost]
        public async Task<IActionResult> Email(string sender, string[] receivers, string message)
        {
            var listeCourriels = new List<MimeMessage>();

            foreach (string adresse in receivers)
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(sender, sender));
                email.To.Add(new MailboxAddress(adresse, adresse));

                email.Subject = "Nouveau message de la part de " + sender;
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

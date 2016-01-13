using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Puissance4_FrontEnd.Models;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace Puissance4_FrontEnd.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string mdpCrypte = Cryptage.getMd5Hash(model.Password);

            using (Data db = new Data())
            {
                var utilisateur = (from u in db.Users where (u.Email == model.Account || u.UserName == model.Account) && u.Password == mdpCrypte select u).FirstOrDefault();

                if (utilisateur != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, utilisateur.ID.ToString()),
                        new Claim(ClaimTypes.Name, utilisateur.UserName),
                        new Claim(ClaimTypes.Email, utilisateur.Email),
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString() + utilisateur.ID.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimTypes.Name, ClaimTypes.Role);
                    var owinContext = HttpContext.GetOwinContext();
                    owinContext.Authentication.SignIn(identity);

                    return RedirectToAction(returnUrl);
                }

                ModelState.AddModelError("", "Tentative de connexion non valide.");
                return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new User();

                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Password = Cryptage.getMd5Hash(model.Password);

                using (Data db = new Data())
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    return RedirectToAction("Login", "Account");
                }
            }

            // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
            return View(model);
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using(Data db = new Data())
            {
                var utilisateur = (from u in db.Users where u.Email == model.Email select u).FirstOrDefault();

                if( utilisateur != null)
                {
                    string mdp = System.Web.Security.Membership.GeneratePassword(8, 2);
                    utilisateur.Password = Cryptage.getMd5Hash(mdp);

                    db.SaveChanges();

                    ViewBag.Resultat = string.Format("Un nouveau mot de passe à été généré : {0}. Vous pouvez maintenant vous connecter avec ce mot de passe.", mdp);

                    return RedirectToAction("/Account/Login");
                }
            }
            
            return View();
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var owinContext = HttpContext.GetOwinContext();
            owinContext.Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
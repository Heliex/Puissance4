using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Puissance4_FrontEnd.Models;
using System.Security.Claims;

namespace Puissance4_FrontEnd.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        //
        // GET: /Manage/Index
        public ActionResult Index()
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            Claim sid = identity.FindFirst(ClaimTypes.Sid);
            var userId = int.Parse(sid.Value);

            using(Data db = new Data())
            {
                var utilisateur = (from u in db.Users where u.ID == userId select u).FirstOrDefault();

                if( utilisateur != null)
                {
                    var model = new IndexViewModel
                    {
                        UserName = utilisateur.UserName,
                        Email = utilisateur.Email
                    };

                    return View(model);
                }
            }

            return RedirectToAction("/Home/Index");
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            Claim sid = identity.FindFirst(ClaimTypes.Sid);
            var userId = int.Parse(sid.Value);

            using (Data db = new Data())
            {
                var utilisateur = (from u in db.Users where u.ID == userId select u).FirstOrDefault();

                if (utilisateur != null)
                {
                    utilisateur.Password = Cryptage.getMd5Hash(model.ConfirmPassword);
                    return View(model);
                }
            }

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
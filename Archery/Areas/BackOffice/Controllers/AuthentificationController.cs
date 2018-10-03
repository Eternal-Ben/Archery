using Archery.Areas.BackOffice.Models;
using Archery.Controllers;
using Archery.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Areas.BackOffice.Controllers
{
    public class AuthentificationController : BaseController
    {
        // GET: BackOffice/Authentification
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthentificationLoginViewModels model)// nom de la Vue retounné : ici la vue AthentificationLoginViewModels
        {
            if (ModelState.IsValid)
            {
                var hash = model.Password.HashMD5();
                var admin = db.Administrators.SingleOrDefault(
                    x => x.Mail == model.Mail && x.Password == hash);

                if (admin == null)
                {
                    ModelState.AddModelError("Mail", "Login / Mot de passe invalide");
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "backoffice" }); // redirect sur un aera
                }
            }
            return View();
        }
    }
}
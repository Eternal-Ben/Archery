﻿using Archery.Areas.BackOffice.Models;
using Archery.Controllers;
using Archery.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Areas.BackOffice.Controllers
{
    public class AuthenticationController : BaseController
    {
        // GET: BackOffice/Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost] // attribut post
        [ValidateAntiForgeryToken] // 
        public ActionResult Login(AuthentificationLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hash = model.Password.HashMD5();
                var admin = db.Administrators.SingleOrDefault(
                    x => x.Mail == model.Mail && x.Password == hash);
                if (admin == null)
                {
                    ModelState.AddModelError("Mail", "Login / mot de passe invalide");
                    return View();
                }
                else
                {
                    Session["ADMINISTRATOR"] = admin;
                    return RedirectToAction("Index", "Dashboard", new { area = "backoffice" });
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("ADMINISTRATOR");
            return RedirectToAction("index", "home", new { area = "" });
        }
    }
}
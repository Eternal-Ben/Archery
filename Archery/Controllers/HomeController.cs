using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{   // Instancie une class pour permettre l'heritage de class, il ne s'agit pas d'une interface, sinon il y aurait un HomeController : IController...
    public class HomeController : Controller
    {
        // GET: Home
        // Appel la methode public qui renvoi un objet de type ActionResult
        public ActionResult Index()
        {
            // retourne la parametre View de la méthode Index qui a été instancié par la methode ActionResult (confirmer la syntax)
            // Viewresult est la class enfant de la methode ActionResult ; notion d'heritage
            return View();
        }

        // Vue about : pour la creation de la View... About donc...
        public  ActionResult About()
        {
            var modelInfo = new Info
            {
                DevName = "Thierry",
                ContactMail = "123@gmail.com",
                CreateDate = DateTime.Now,
           };
            // Pour retourner la valeur de la variable modelInfo instancié par l'objet View
            return View(modelInfo);

          /// si remplacement d'attributs avec les models geré par les controllers, preciser le parametre genre
          /// nom de l'objet [parametre]
          ///
        }
    }
}
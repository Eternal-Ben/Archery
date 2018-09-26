using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{   // Appel une class pour permettre l'heritage de class, il ne s'agit pas d'une interface, sinon il y aurait un HomeController : IController...
    public class HomeController : Controller
    {
        // GET: Home
        // Appel la methode public qui renvoi un objet de type ActionResult
        public ActionResult Index()
        {
            //ViewBag & ViewData à voir : echanger des donnees dans le cicle d'execution
            ViewData["Title"] = "Accueil"; // peut charger des objets, mais attention uniquement des objets simple.

            // retourne la parametre View de la méthode Index qui a été instancié par la methode ActionResult (confirmer la syntax)
            // Viewresult est la class enfant de la methode ActionResult ; notion d'heritage
            return View();
        }

        // On indique le chemin de la route par une propriété ci dessous, autre technique
        //[Route("a-propros")]
        // Vue about : pour la creation de la View... About donc...
        public ActionResult About()
        {
            // permet le titrage de la page web dynamiquement
            ViewData["Title"] = "About";
            var modelInfo = new Info

            {
                DevName = "Thierry",
                ContactMail = "123@gmail.com",
                CreateDate = DateTime.Today,
           };
            // Pour retourner la valeur de la variable modelInfo instancié par l'objet View
            return View(modelInfo);

          /// si remplacement d'attributs avec les models geré par les controllers, preciser le parametre genre
          /// nom de l'objet [parametre]
          ///
        }


        //Un actionresult Challenge pour la creation du contenu de la View, il faut penser d'abord à creer son model avec ses paramêtres dans les Views
        public ActionResult Challenge()
        {
            ViewData["Challenge"] = "Challenge";
            var modelChallenge = new Challenge
            //{
            //    parametre des variables à ajouter, puis creer un View Challenge pour l'affichage 
            //};
            return View();
        }
    }
}
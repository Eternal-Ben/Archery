using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{   // "nom de notre classe qui ": > herite" d'une class mère Controller, il ne s'agit pas d'une interface, sinon il y aurait un HomeController : IController...
    public class HomeController : BaseController
    {
        // GET: Home
        // Appel le resulat de la methode Index qui est de type ActionResult qui est en acces public
        public ActionResult Index()
        {
            // ViewBag (dynamique) : Recupère le dictionnaire de données d'affichage de facon dynamique.et va garantir l'echange des donnees durant le cicle d'execution de la View (<?).
            // ViewData (non-dynamique)  : Recupère ou définit le dictionnaire pour les données d'affichage durant le cycle d'execution de la View.

            ViewData["Title"] = "Accueil"; // peut charger des objets, mais attention uniquement des objets simple.

            // retourne la parametre View de la méthode Index qui a été instancié par la methode ActionResult (confirmer la syntax)
            // Viewresult est la class enfant de la methode ActionResult ; notion d'heritage
            return View();
        }

        // On indique le chemin de la route par une propriété ci dessous
        //[Route("a-propros")]
        // Vue about : pour la creation de la View... About donc...
        public  ActionResult About()
        {
            // permet le titrage de la page web dynamiquement | dispo dans le control et les Views qui seront apl | dispo le temps d'execution du cycle partout. identique a une autre variable qui elle n'est pas dynamique mais dans le dictionnaire | passer des donnees au control ou aux vues le temps d'execution propre au controleur
            ViewData["Title"] = "About";
            var modelInfo = new Info //creation de l'objet Info

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
    }
}
using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class ArchersController : Controller
    {
        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }

        // Le parametre [HttpPost] permet une recuperation du flux de donnée du Post
        [HttpPost]
        // On accede à la methode de la class xx grace au parametre "email" passé en argument à l'objet Subscribe qui a un modificateur d'acces public, donc visible par les methodes enfants et ses class parents
        public ActionResult Subscrsibe(Archer archer)
        {
            // On test si la valeur est valide
            if (DateTime.Now.AddYears(-9) <= archer.BirthDate)
            {
                //Technique simple et rapide :
                //ViewBag.Erreur = "Age non requis";
                //return View();
                ModelState.AddModelError("Birthday","Date de naissance",)
            }

            if (ModelState.IsValid)

            {
              //int AgeLimit = 9;
              //                   ArcherLimitDate = 
              // if (AgeLimit - archer.BirthDate > 9)
               // return acces ok
                //Qhand qlq chose n'existe pas il faut le creer'
                //DateTime.Birthdate is true | A travailler
            }
            return View();

        }
    }
}
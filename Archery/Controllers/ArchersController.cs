using Archery.Data;
using Archery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class ArchersController : BaseController
    { 
        // A faire absolument : override le dispo pour libere la connection a la base pour eviter les fuites sql
        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }

        // permet la validation de du Token/clee
        [ValidateAntiForgeryToken]
        // Le parametre [HttpPost] permet une recuperation du flux de donnée du Post
        [HttpPost]
        // On accede à la methode de la class xx grace au parametre "email" passé en argument à l'objet Subscribe qui a un modificateur d'acces public, donc visible par les methodes enfants et ses class parents
        public ActionResult Subscribe([Bind(Exclude = "ID")]Archer archer) // Bind(Exclude = "nom du parametre de l'objet" à exclure | Bind(Include.... - il s'agit d'une protection suplementaire entre l'association et l'objet d'une formulaire
        {
            // On test si la valeur est valide
           /* if (DateTime.Now.AddYears(-9) <= archer.BirthDate)
       
                //Technique simple et rapide :
                //ViewBag.Erreur = "Age non requis";
                //return View();
                ModelState.AddModelError("Birthday", "Date de naissance");
            }*/

            if (ModelState.IsValid)
            {
                db.Archers.Add(archer);
                db.SaveChanges();

                // Exemple 1 pour renvoie sur la page Index/Home
                //TempData["Message"] = "Arché Enregistré";
                Display("Archer enregistré");
                return RedirectToAction("index", "home");
            }
            
            return View();
        }

    }
}
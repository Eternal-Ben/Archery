using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

//derniere route ajouté est celle qui repond à la demande

namespace Archery
{
    // Precise la route pour nos controllers
    public class RouteConfig
    {   
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Pour utiliser un controller, il faut declarer la route du MVC
            routes.MapMvcAttributeRoutes(); // Remplacement de l'attribut dans le model de class

            // routes.MapRoute(
            //   name: "Default2",
            //   url: "{controller}/{action}/.hmtl/{id}", // route, chemin d'acces de l'url pour le server (confirmer le terme server)
            //   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);*/

// Mappage, Reecriture d'url, redirection de page Home>About
            routes.MapRoute(
                name:"AboutRoute",
                url: "a-propos",
                defaults : new {controller = "Home", action = "About"}
                );
            
            routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}", // route, chemin d'acces de l'url pour le server (confirmer le terme server)
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                 );


            


        }
    }
}

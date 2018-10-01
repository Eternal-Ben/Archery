using System.Web.Mvc;

namespace Archery.Areas.BackOffice
{
    public class BackOfficeAreaRegistration : AreaRegistration 
    {// paramettre sans ()
        public override string AreaName 
        {
            get 
            {
                return "BackOffice";
            }
        }
        // class car avec ()
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BackOffice_default",
                "BackOffice/{controller}/{action}/{id}",
                new { controller = "DashBoard", action = "Index", id = UrlParameter.Optional } // eviter les memes nom dans plusieurs aera
            );
        }
    }
}
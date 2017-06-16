using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Stationnement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name:"Blog",
            //    url:"blog/{annee}/{mois}/{jour}/{description}",
            //    defaults: new { controller = "Math", action = "Blog" },
            //    constraints: new { annee=@"\d{4}", mois = @"\d{1,2}", jour = @"\d{1,2}" }
            // );

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

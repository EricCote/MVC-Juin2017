using Stationnement.Migrations;
using Stationnement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Stationnement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StationnementContext, Configuration>());

            
        }

        protected void Application_BeginRequest()
        {
            Thread.CurrentThread.CurrentCulture =
               CultureInfo.CreateSpecificCulture("fr-CA");
        }

        

    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Stationnement
{
    public class FrancaisAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Thread.CurrentThread.CurrentCulture =
                CultureInfo.CreateSpecificCulture("fr-CA");

            base.OnActionExecuting(filterContext);

        }

      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stationnement.Controllers
{
    public class SecureController : Controller
    {
        // GET: Secure
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = @"VS2017-ERIC\secret")]
        public ActionResult Secret()
        {
            return View();
        }
    }
}
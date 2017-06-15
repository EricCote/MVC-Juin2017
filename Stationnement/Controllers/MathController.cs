using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stationnement.Controllers
{
    public class MathController : Controller
    {
        // GET: Math
        public ActionResult Index()
        {
            return View();
        }

        // GET: Math/Divide
        public ActionResult Divide()
        {
            return View();
        }


        // Post: Math/Divide
        [HttpPost()]
        [HandleError(View = "DivideError")]
        [HandleError(View = "DivideZeroError",ExceptionType =  typeof(DivideByZeroException))]
        public ActionResult Divide(int terme1, int terme2)
        {
            int result = terme1 / terme2;

            return View(result);
        }
    }
}
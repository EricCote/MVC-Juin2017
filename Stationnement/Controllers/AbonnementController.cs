using Stationnement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stationnement.Controllers
{
    public class AbonnementController : Controller
    {
        // GET: Abonnement
        public ActionResult Index()
        {
            AWContext db = new AWContext();
            List<string> pays = db.Addresses.Select(ad => ad.CountryRegion).Distinct().ToList();
            ViewBag.Pays = pays;


            return View();
        }

        public ActionResult Inscription(Inscription ins)
        {
            StationnementContext db = new StationnementContext();
            db.Inscriptions.Add(ins);
            db.SaveChanges();

            return View(ins);
        }
    }
}
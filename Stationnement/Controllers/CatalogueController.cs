using Stationnement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stationnement.Controllers
{


    public class CatalogueController : Controller
    {
        // GET: Catalogue
        public ActionResult Index()
        {
            AWContext db = new AWContext();
            db.Database.Log = msg => Debug.Write(msg);
            List<Product> produits = db.Products.Take(10).Include("ProductModel").ToList();

            return View(produits);
        }

        // GET: Catalogue/Details/5
        public ActionResult Details(int id)
        {
            AWContext db = new AWContext();
            db.Database.Log = msg => Debug.Write(msg);
            Product produit = db.Products.Include("Category").
                                          Include("ProductModel").
                                          Where(p => p.ProductID==id).
                                          FirstOrDefault();
            if (produit == null)
                return HttpNotFound();
            return View(produit);
        }

        // GET: Catalogue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogue/Create
        [HttpPost]
        public ActionResult Create(Product produit)
        {
            try
            {
                AWContext db = new AWContext();
                db.Products.Add(produit);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Catalogue/Edit/5
        public ActionResult Edit(int id)
        {
            AWContext db = new AWContext();
            Product produit = db.Products.Find(id);
            if (produit == null)
                return HttpNotFound();

            ViewBag.ProductCategoryID = new SelectList(db.Categories, "CategoryID", "Name", produit.ProductCategoryID);
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", produit.ProductModelID);

            return View(produit);
        }

        // POST: Catalogue/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            AWContext db = new AWContext();
            try
            {
                ViewBag.ProductCategoryID = new SelectList(db.Categories, "CategoryID", "Name", product.ProductCategoryID);
                ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);

                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Catalogue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Catalogue/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

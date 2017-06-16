using Stationnement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Stationnement.Controllers
{


    public class CatalogueController : Controller
    {
        // GET: Catalogue
        public ActionResult Index(string categorie,string subcategory)
        {
            List<Product> produits = genererListeProduits(categorie, subcategory);

            return View(produits);
        }

        private List<Product> genererListeProduits(string categorie,  string subcategory)
        {
            AWContext db = new AWContext();

            if (string.IsNullOrEmpty(categorie)) subcategory = null;

            List<Category> categories = db.Categories.Where(c => c.ParentCategory == null).
                                        OrderBy(c => c.Name).ToList();

            List<Category> subcategories = db.Categories.Where(c => c.ParentCategory.Name == categorie).
                                           OrderBy(c => c.Name).ToList();

            List<Product> produits = db.Products.Where(p =>
                                     !string.IsNullOrEmpty(subcategory) ? p.Category.Name == subcategory : (
                                     !string.IsNullOrEmpty(categorie) ? p.Category.ParentCategory.Name == categorie :
                                     true
                                     )).
                                     Take(10).Include("ProductModel").ToList();

            ViewBag.Cat = categories;
            ViewBag.Sub = subcategory;

            ViewBag.categorie = new SelectList(categories, "Name", "Name", categorie);
            ViewBag.subcategory = new SelectList(subcategories, "Name", "Name", subcategory);
            return produits;
        }

        public PartialViewResult Grille(string categorie, string subcategory)
        {
            List<Product> produits = genererListeProduits(categorie, subcategory);

            return PartialView("_Grille", produits);
        }


        async public Task<ActionResult> All()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:50429/api/catalog");

            List<Product> products = null;
            if (response.IsSuccessStatusCode)
            {
               products = await response.Content.ReadAsAsync<List<Product>>();
            }
            return View(products);
        }



        // GET: Catalogue/Details/5
        public ActionResult Details(int id)
        {
            AWContext db = new AWContext();

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

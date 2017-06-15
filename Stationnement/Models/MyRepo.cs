using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stationnement.Models
{
    public class MyRepo
    {
        public List<Product> GetAllProducts()
        {
            AWContext db = new AWContext();
            return db.Products.ToList();
        }
        public List<Product> GetProducts(string color)
        {
            AWContext db = new AWContext();
            return db.Products.Where(p => p.Color== color).ToList();
        }
        public List<Product> GetProductsByName(string name)
        {
            AWContext db = new AWContext();
            return db.Products.Where(p => p.Name.StartsWith(name)).ToList();
        }
    }
}
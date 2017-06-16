using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWRepository
{
    public class AWRepo
    {
        public List<Product> GetAllProducts()
        {
            AWContext db = new AWContext();
            return db.Products.Include("ProductCategory").ToList();
        }

        public List<Product> GetProducts(string name)
        {
            AWContext db = new AWContext();
            return db.Products.Include("ProductCategory").
                               Where(p=> p.Name.StartsWith(name)).
                               ToList();
        }

    }
}

using AWRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWAPI.Controllers
{
    public class CatalogController : ApiController
    {
        // api/Catalog
        public List<Product> Get()
        {
            AWRepo repo = new AWRepo();
            return repo.GetAllProducts();
        }

        //  api/Catalog/Road
        public List<Product> Get(string id)
        {
            AWRepo repo = new AWRepo();
            return repo.GetProducts(id);
        }

    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Models;

namespace Controllers
{
    [Produces("application/json")]
    [Route("/")]
    public class ProductsController
    {
        Products[] products = new Products[] 
        {
            new Products { Code = "1", Description = "Primero" },
            new Products { Code = "2", Description = "Segundo" },
            new Products { Code = "3", Description = "Tercero" }
        };

        [HttpGet]
        public IEnumerable<Products> ListAllProds()
        {
            return products;
        }

        [HttpGet("code/{codart}")]
        public IEnumerable<Products> ListProductsByCode(string codart)
        {
            IEnumerable<Products> retVal =
                from g in products
                where g.Code.Equals(codart)
                select g;
            
            return retVal;
        }

        [HttpGet("description/{desart}")]
        public IEnumerable<Products> ListProductsByDescription(string desart)
        {
            IEnumerable<Products> retVal =
            from g in products
            where g.Description.ToLower().Contains(desart.ToLower())
            orderby g.Code
            select g;

            return retVal;
        }
    }
}
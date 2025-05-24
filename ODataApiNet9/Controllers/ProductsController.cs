using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataApiNet9.Models;

namespace ODataApiNet9.Controllers
{
    public class ProductsController : ODataController
    {
        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Phone", Price = 800 }
        };

        [EnableQuery]
        public ActionResult<IQueryable<Product>> Get()
        {
            return Ok(Products.AsQueryable());
        }

        [EnableQuery]
        public ActionResult<Product> Get(int key)
        {
            var product = Products.FirstOrDefault(p => p.Id == key);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}

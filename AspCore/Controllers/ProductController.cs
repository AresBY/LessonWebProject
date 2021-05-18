using AspCore.Classes;
using AspCore.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore.Controllers
{
    public class ProductController : Controller
    {
        private  ProductContext _db;
        public ProductController(ProductContext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult ShowProducts(ProductType category, int minPrice, int maxPrice)
        {
            var result = _db.Products.Where(t =>
            (category == ProductType.All || category == t.Type) &&
            t.Price >= minPrice &&
            t.Price <= maxPrice);

            return View(result);
        }

        public IActionResult ChoiceProducts()
        {
            return View();
        }
    }
}

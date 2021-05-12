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
        [HttpPost]
        public IActionResult ShowProducts(ProductType category, int minPrice, int maxPrice)
        {
            ProductContext db = new ProductContext();

            var result = db.Products.Where(t =>
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

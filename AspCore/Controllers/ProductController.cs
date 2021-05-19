using DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
       
        [HttpPost]
        public IActionResult ShowProducts(CategoryType category, int minPrice, int maxPrice)
        {
            //var result = _db.Products.Where(t =>
            //(category == ProductType.All || category == t.Type) &&
            //t.Price >= minPrice &&
            //t.Price <= maxPrice);

            //return View(result);
            return View();
        }

        public IActionResult ChoiceProducts()
        {
            return View();
        }
    }
}

using DataLayer.Entityes;
using DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore.Controllers
{
    public class UserTaskController : Controller
    {
        public IActionResult CreateNewTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetNewTaskData(CategoryType category, int maxPrice, string keyWords)
        {
            //BusinessLayer.BusinessManager
            //var result = _db.Products.Where(t =>
            //(category == ProductType.All || category == t.Type) &&
            //t.Price >= minPrice &&
            //t.Price <= maxPrice);

            //return View(result);
            return View();
        }
    }
}

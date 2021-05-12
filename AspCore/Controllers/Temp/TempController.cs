using AspCore.Classes;
using AspCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore.TempData
{
    public class TempController : Controller
    {
        public IActionResult ShowProducts()
        {
            //DBInitialization();
            ProductContext db = new ProductContext();
            return View(db.Products);
        }
      
       
        public void DBInitialization()
        {
            using (ProductContext db = new ProductContext())
            {
                Random ran = new Random();
                for (int i = 0; i < 10; i++)
                {
                    db.Products.Add(new ProductModel(Enums.ProductType.Car, ran.Next(5000, 50000), ran.Next(0, 2) > 0 ? "Mazda" : "Honda"));
                    db.Products.Add(new ProductModel(Enums.ProductType.Computer, ran.Next(100, 300), ran.Next(0, 2) > 0 ? "PC" : "Notebook"));
                    db.Products.Add(new ProductModel(Enums.ProductType.Food, ran.Next(1, 30), ran.Next(0, 2) > 0 ? "Bread" : "Milk"));
                }
                db.SaveChanges();

            }
        }
    }
}

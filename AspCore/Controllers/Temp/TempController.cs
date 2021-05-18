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
        private ProductContext _db;
        public TempController(ProductContext db)
        {
            _db = db;
        }

        public IActionResult ShowProducts()
        {
            //DBInitialization();
        
            return View(_db.Products);
        }
      
       
        public void DBInitialization()
        {
           
                Random ran = new Random();
                for (int i = 0; i < 10; i++)
                {
                    _db.Products.Add(new ProductModel(Enums.ProductType.Car, ran.Next(5000, 50000), ran.Next(0, 2) > 0 ? "Mazda" : "Honda"));
                    _db.Products.Add(new ProductModel(Enums.ProductType.Computer, ran.Next(100, 300), ran.Next(0, 2) > 0 ? "PC" : "Notebook"));
                    _db.Products.Add(new ProductModel(Enums.ProductType.Food, ran.Next(1, 30), ran.Next(0, 2) > 0 ? "Bread" : "Milk"));
                }
            _db.SaveChanges();

           
        }
    }
}

using AspCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore.Models
{
    public class ProductModel
    {
        [Key]
        public int ID { get; set; }
        public ProductType Type { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public ProductModel()
        { }
        public ProductModel(ProductType type, int price, string name)
        {
            Type = type;
            Price = price;
            Name = name;
        }
    }
}

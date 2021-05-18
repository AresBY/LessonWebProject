using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models.View
{
    public class ProductViewModel
    {
        public CategoryType CategoryType { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}

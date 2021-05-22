
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models.View
{
    public class UserTaskViewModel
    {
        public UserTaskViewModel() { }
        public UserTaskViewModel(CategoryType categoryType, int maxPrice, string keyWords)
        {
            CategoryType = categoryType;
            Price = maxPrice;
            Keywords = keyWords;
        }

        [Key]
        public int ID { get; set; }
        public CategoryType CategoryType { get; set; }
        public int Price { get; set; }
        public string Keywords { get; set; }
    }
   
}

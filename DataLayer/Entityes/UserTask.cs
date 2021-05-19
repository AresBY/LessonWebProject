using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entityes
{
    public class UserTask
    {
        public int ID { get; set; }
        public CategoryType CategoryType { get; set; }
        public int Price { get; set; }
        public string Keywords { get; set; }
        public UserTask(CategoryType categoryType, int price, string keywords)
        {
            CategoryType = categoryType;
            Price = price;
            Keywords = keywords;
        }
    }
}

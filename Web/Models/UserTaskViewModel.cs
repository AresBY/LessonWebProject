using LessonWebProject.Common.Enums;
using LessonWebProject.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LessonWebProject.Web.Models
{
    public class UserTaskViewModel
    {
        public UserTaskViewModel() { }
        //public UserTaskViewModel(CategoryType categoryType, int maxPrice, string keyWords)
        //{
        //    CategoryType = categoryType;
        //    Price = maxPrice;
        //    Keywords = keyWords;
        //}
        public UserTaskViewModel(UserTaskModel input)
        {
            ID = input.ID;
            UserID = input.UserID;
            CategoryType = input.CategoryType;
            Price = input.Price;
            Keywords = input.Keywords;
        }
        public int ID { get; set; }
        public string UserID { get; set; }
        public CategoryType CategoryType { get; set; }
        public int Price { get; set; }
        public string Keywords { get; set; }
    }
}

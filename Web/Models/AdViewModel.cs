using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LessonWebProject.Web.Models
{
    public class AdViewModel
    {
        public AdViewModel() { }
        public AdViewModel(AdModel input)
        {
            ID = input.ID;
            UserID = input.UserID;
            CategoryType = input.CategoryType;
            Price = input.Price;
            Phone = input.Phone;
            WasFoundedDate = input.WasFoundedDate;
            KufarID = input.KufarID;
        }
        public int ID { get; set; }
        public string UserID { get; set; }
        public string KufarID { get; set; }
        public CategoryType CategoryType { get; set; }
        public int Price { get; set; }
        public string Phone { get; set; }

        public DateTime WasFoundedDate { get; set; }
        public override string ToString()
        {
            return $"UserID {UserID} CategoryType {CategoryType} Price{Price} Phone {Phone} Дата { WasFoundedDate}";
        }
    }
}

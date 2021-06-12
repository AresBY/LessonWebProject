using LessonWebProject.Common.Enums;
using LessonWebProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.BusinessLogic.Models
{
    public class AdModel
    {
        public AdModel(AdDBModel input)
        {
            ID = input.ID;
            TaskID = input.TaskID;
            UserID = input.UserID;
            KufarID = input.KufarID;
            CategoryType = input.CategoryType;
            Price = input.Price;
            Description = input.Description;
            Phone = input.Phone;
            WasFoundedDate = input.WasFoundedDate;
        }
        public int ID { get; set; }
        public int TaskID { get; set; }
        public string UserID { get; set; }
        public string KufarID { get; set; }
        public CategoryType CategoryType { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }

        public DateTime WasFoundedDate { get; set; }

        public override string ToString()
        {
            return $"UserID {UserID} TaskID{TaskID} CategoryType {CategoryType} Price{Price} Phone {Phone} Дата {WasFoundedDate}";
        }
    }
}

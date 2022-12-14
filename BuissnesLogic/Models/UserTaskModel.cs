using LessonWebProject.Common.Enums;
using LessonWebProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.BusinessLogic.Models
{
    public class UserTaskModel
    {
        public UserTaskModel() { }
      
        public int ID { get; set; }
        public string UserID { get; set; }
        public CategoryType CategoryType { get; set; }
        public int Price { get; set; }
        public string Keywords { get; set; }

        public override string ToString()
        {
            return $"UserID: {UserID} Type: {CategoryType} Price: {Price} Keywords {Keywords}";
        }
    }
}

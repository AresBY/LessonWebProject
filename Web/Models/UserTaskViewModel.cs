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
       
        public int ID { get; set; }
        public string UserID { get; set; }
        public CategoryType CategoryType { get; set; }
        public int Price { get; set; }
        public string Keywords { get; set; }
    }
}

using LessonWebProject.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LessonWebProject.Data.Models.DB
{
    public class AdDBModel
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public CategoryType CategoryType { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Images { get; set; }
        public bool HasBeenSent { get; set; }

        public override string ToString()
        {
            return $"UserID {UserID} CategoryType {CategoryType} Price{Price} Phone {Phone}";
        }
    }
}

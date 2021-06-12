using LessonWebProject.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LessonWebProject.Data.Models
{
    public class AdDBModel
    {
        [Key]
        public int ID { get; set; }
        public int TaskID { get; set; }
        public string UserID { get; set; }
        public string KufarID { get; set; }
        public CategoryType CategoryType { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Images { get; set; }
        public bool HasBeenSent { get; set; }

        public DateTime WasFoundedDate { get; set; }

        public override string ToString()
        {
            return $"UserID {UserID} TaskID{TaskID} CategoryType {CategoryType} Price{Price} Phone {Phone} Дата {WasFoundedDate}";
        }
    }
}

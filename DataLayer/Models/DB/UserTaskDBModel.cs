
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models.DB
{
   
    public class UserTaskDBModel
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public CategoryType CategoryType { get; set; }
        public int Price { get; set; }
        public string Keywords { get; set; }
    }
}

﻿using LessonWebProject.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LessonWebProject.Data.Models
{ 
    public class UserTaskDBModel
    {
        [Key]
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

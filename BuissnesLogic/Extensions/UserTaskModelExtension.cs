using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.BusinessLogic.Extensions
{
    public static class UserTaskModelExtension
    {
        public static UserTaskDBModel ToDBModel(this UserTaskModel input)
        {
            UserTaskDBModel userTaskDBModel = new UserTaskDBModel()
            {
                ID = input.ID,
                UserID = input.UserID,
                CategoryType = input.CategoryType,
                Price = input.Price,
                Keywords = input.Keywords
            };
            return userTaskDBModel;
        }
    }
}

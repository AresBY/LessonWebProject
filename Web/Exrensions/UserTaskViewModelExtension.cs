using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonWebProject.Web.Exrensions
{
    public static class UserTaskViewModelExtension
    {
        public static UserTaskModel ToModel(this UserTaskViewModel input)
        {
            UserTaskModel userTaskDBModel = new UserTaskModel()
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

using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonWebProject.BusinessLogic.Extensions
{
    public static class BusinessModels
    {
        public static UserTaskDBModel toUserTaskDBModel(this UserTaskModel input)
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
        public static UserTaskModel toUserTaskModel(this UserTaskDBModel input)
        {
            UserTaskModel userTaskModel = new UserTaskModel()
            {
                ID = input.ID,
                UserID = input.UserID,
                CategoryType = input.CategoryType,
                Price = input.Price,
                Keywords = input.Keywords
            };
            return userTaskModel;
        }
        public static IEnumerable<UserTaskModel> toUserTaskModel(this IEnumerable<UserTaskDBModel> input)
        {
            return input.Select(t => t.toUserTaskModel());
        }
        public static AdModel toAdModel(this AdDBModel input)
        {
            AdModel adModel = new AdModel()
            {
                ID = input.ID,
                TaskID = input.TaskID,
                UserID = input.UserID,
                KufarID = input.KufarID,
                CategoryType = input.CategoryType,
                Price = input.Price,
                Description = input.Description,
                Phone = input.Phone,
                WasFoundedDate = input.WasFoundedDate,
            };
            return adModel;
        }
        public static IEnumerable<AdModel> toAdModel(this IEnumerable<AdDBModel> input)
        {
            return input.Select(t => t.toAdModel());
        }

        
    }
}

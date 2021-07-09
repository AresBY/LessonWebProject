using LessonWebProject.BusinessLogic.Models;
using LessonWebProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonWebProject.Web.Extensions
{
    public static class WebModels
    {
        public static UserTaskModel toUserTaskModel(this UserTaskViewModel input)
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
        public static UserTaskViewModel toContract(this UserTaskModel input)
        {
            UserTaskViewModel userTaskViewModel = new UserTaskViewModel()
            {
                ID = input.ID,
                UserID = input.UserID,
                CategoryType = input.CategoryType,
                Price = input.Price,
                Keywords = input.Keywords
            };
            return userTaskViewModel;
        }
        public static IEnumerable<UserTaskViewModel> toContract(this IEnumerable<UserTaskModel> input)
        {
            return input.Select(t => t.toContract());
        }

        public static AdViewModel toContract (this AdModel input)
        {
            AdViewModel adViewModel = new AdViewModel()
            {
                ID = input.ID,
                UserID = input.UserID,
                CategoryType = input.CategoryType,
                Price = input.Price,
                Phone = input.Phone,
                WasFoundedDate = input.WasFoundedDate,
                KufarID = input.KufarID
            };
            return adViewModel;
        }
        public static IEnumerable<AdViewModel> toContract(this IEnumerable<AdModel> input)
        {
            return input.Select(t => t.toContract());
        }
    }
}

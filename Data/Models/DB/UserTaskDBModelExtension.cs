
using LessonWebProject.Data.Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Data.Models.DB
{
    public static class UserTaskDBModelExtension
    {
        public static UserTaskDBModel toDBModel(this UserTaskViewModel input, string userID)
        {
            UserTaskDBModel output = new UserTaskDBModel()
            {
                ID = input.ID,
                UserID = userID,
                CategoryType = input.CategoryType,
                Price = input.Price,
                Keywords = input.Keywords
            };
            return output;
        }
        public static IEnumerable<UserTaskDBModel> toDBModel(this IEnumerable<UserTaskViewModel> input, string userID)
        {
            List<UserTaskDBModel> output = new List<UserTaskDBModel>();
            foreach (var model in input)
            {
                output.Add(model.toDBModel(userID));
            }
            return output;
        }
    }
}

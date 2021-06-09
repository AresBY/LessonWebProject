﻿
using LessonWebProject.Data.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Data.Models.View
{
    public static class UserTaskDBModelExtension
    {
        public static UserTaskViewModel toContract(this UserTaskDBModel input)
        {
            UserTaskViewModel output = new UserTaskViewModel()
            {
                ID = input.ID,
                CategoryType = input.CategoryType,
                Price = input.Price,
                Keywords = input.Keywords
            };

            return output;
        }
        public static IEnumerable<UserTaskViewModel> toContract(this IEnumerable<UserTaskDBModel> input)
        {
            List<UserTaskViewModel> output = new List<UserTaskViewModel>();
            foreach (var model in input)
            {
                output.Add(model.toContract());
            }
            return output;
        }
    }
}

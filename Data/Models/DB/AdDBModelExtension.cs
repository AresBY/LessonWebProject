
using LessonWebProject.Data.Models.DB;
using LessonWebProject.Data.Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Data.Models.DB
{
    public static class AdDBModelExtension
    {
        public static AdViewModel toContract(this AdDBModel input)
        {
            AdViewModel output = new AdViewModel()
            {
                ID = input.ID,
                UserID = input.UserID,
                CategoryType = input.CategoryType,
                Price = input.Price,
                Phone = input.Phone,
                WasFoundedDate = input.WasFoundedDate,
                KufarID = input.KufarID
            };

            return output;
        }
        public static IEnumerable<AdViewModel> toContract(this IEnumerable<AdDBModel> input)
        {
            List<AdViewModel> output = new List<AdViewModel>();
            foreach (var model in input)
            {
                output.Add(model.toContract());
            }
            return output;
        }
    }
}

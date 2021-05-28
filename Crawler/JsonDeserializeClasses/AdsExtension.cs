using LessonWebProject.Common.Enums;
using LessonWebProject.Common.Models.DB;
using LessonWebProject.Crawler.JsonDeserializeClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Crawler
{
    public static class AdsExtension
    {
        public static FoundAdDBModel toFoundAdDBModel(this Product input, string userID, CategoryType categoryType)
        {
            FoundAdDBModel output = new FoundAdDBModel()
            {
                UserID = userID,
                CategoryType = categoryType,
                Price = input.price,
                Description = input.description,
                Phone = input.phone,
                Images = input.images
            };
            return output;
        }
    }
}

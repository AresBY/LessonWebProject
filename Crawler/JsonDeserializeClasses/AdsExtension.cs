using LessonWebProject.Common.Enums;
using LessonWebProject.Crawler.JsonDeserializeClasses;
using LessonWebProject.Data.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Crawler
{
    public static class AdsExtension
    {
        public static AdDBModel toFoundAdDBModel(this Product input, string userID, CategoryType categoryType)
        {
            AdDBModel output = new AdDBModel()
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

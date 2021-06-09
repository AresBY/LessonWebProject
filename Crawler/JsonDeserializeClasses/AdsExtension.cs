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
        public static AdDBModel toAdDBModel(this Product input,int taskID, string userID, CategoryType categoryType, string kufarID)
        {
            AdDBModel output = new AdDBModel()
            {
                UserID = userID,
                TaskID = taskID,
                CategoryType = categoryType,
                Price = input.price,
                Description = input.description,
                Phone = input.phone,
                Images = input.images,
                KufarID = kufarID
            };
            return output;
        }
    }
}

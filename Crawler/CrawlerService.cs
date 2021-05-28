using LessonWebProject.Common.Enums;
using LessonWebProject.Common.Models.DB;
using LessonWebProject.Crawler.JsonDeserializeClasses;
using LessonWebProject.Data;
using LessonWebProject.Data.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;

namespace LessonWebProject.Crawler
{
    public class CrawlerService
    {
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IFoundAdsRepository _foundTaskRepository;
        public CrawlerService(IUserTaskRepository userTaskRepository, IFoundAdsRepository foundTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
            _foundTaskRepository = foundTaskRepository;
        }

        public void DoSearching()
        {
            var dbTasks = _userTaskRepository.GetAllUsersTasks();
          
            IEnumerable<CategoryType> categories = dbTasks.Select(t => t.CategoryType).Distinct();

            //foreach (var v in categories) Console.WriteLine(v);
            List<FoundAdDBModel> output = new List<FoundAdDBModel>();
            foreach (var category in categories)
            {
                var adsByCategory = GetAdsFromKufarByCategory(category);
                var tasks = dbTasks.Where(t => t.CategoryType == category);

                foreach (var task in tasks)
                {
                    IEnumerable<Product> currentAds = adsByCategory.data.Where(t => t.price <= task.Price);
                    output.AddRange(currentAds.Select(t => t.toFoundAdDBModel(task.UserID, task.CategoryType)));
                }
            }

            _foundTaskRepository.SaveAds(output);
        }

        public void ShowAds()
        {
            var res = _foundTaskRepository.GetAllFoundAds();
            foreach(var v in res)
            {
                Console.WriteLine(v);
            }
        }

        public ProductRoot GetAdsFromKufarByCategory(CategoryType category)
        {
            ProductRoot splashInfo;
            WebRequest request = WebRequest.Create(
                $"{StaticParameters.UrlLoginToken}&category_id={(int)category}&limit={StaticParameters.LimitProducts}");

            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    splashInfo = JsonConvert.DeserializeObject<ProductRoot>(reader.ReadToEnd());
                }
            }
            response.Close();
            return splashInfo;
        }
    }
}

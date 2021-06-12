using LessonWebProject.Common.Enums;
using LessonWebProject.Crawler.JsonDeserializeClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.Data.Models;

namespace LessonWebProject.Crawler
{
    public class CrawlerService
    {
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IAdsRepository _adRepository;
        public CrawlerService(IUserTaskRepository userTaskRepository, IAdsRepository adRepository)
        {
            _userTaskRepository = userTaskRepository;
            _adRepository = adRepository;
        }

        public void DoSearching()
        {
            var dbTasks = _userTaskRepository.GetAllUsersTasks();

            // Тут сделанно именно в таком порялке, чтобы максимально сократить кол-во вызовов от Куфара
            IEnumerable<CategoryType> categories = dbTasks.Select(t => t.CategoryType).Distinct();

            List<AdDBModel> output = new List<AdDBModel>();
            foreach (var category in categories)
            {
                var adsByCategory = GetAdsFromKufarByCategory(category);
                var tasks = dbTasks.Where(t => t.CategoryType == category);

                foreach (var task in tasks)
                {
                    IEnumerable<Product> currentAds = adsByCategory.data.Where(t => t.price <= task.Price);
                    output.AddRange(currentAds.Select(t => t.toAdDBModel(task.ID, task.UserID, task.CategoryType, t.Id)));
                }
            }

            _adRepository.SaveFreshAds(output);
          
        }

        public void ShowAds()
        {
            var res = _adRepository.GetAllAds();
            foreach (var v in res)
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

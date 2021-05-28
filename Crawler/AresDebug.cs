using LessonWebProject.Crawler.JsonDeserializeClasses;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace LessonWebProject.Crawler
{
    public static class AresDebug
    {
        public static void ShowLimits()
        {
            WebRequest request = WebRequest.Create(StaticParameters.UrlLimit);
            WebResponse response = request.GetResponse();
           
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    var splashInfo = JsonConvert.DeserializeObject<ApiLimitRoot>(result);
                    Console.WriteLine($"Осталось использований {splashInfo.data.api_limit.of - splashInfo.data.api_limit.used}");
                }
            }
            response.Close();
        }
    }
}

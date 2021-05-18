using Newtonsoft.Json;
using Spider.JsonDeserializeClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Spider
{
    class Program
    {
        static void Main(string[] args)
        {
            AresDebug.ShowLimits();

            ProductRoot splashInfo = GetProducts(CategoryType.Cars);

            Console.WriteLine(splashInfo);

            Console.ReadKey();
        }

        private static ProductRoot GetProducts(CategoryType category)
        {
            ProductRoot splashInfo;
            WebRequest request = WebRequest.Create(GetProductUriString((int)category));

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

        private static string GetProductUriString(int category, int limit = StaticParameters.LimitProducts)
        {
            return $"{StaticParameters.UrlLoginToken}&category_id={category}&limit={limit}";
        }
    }
}

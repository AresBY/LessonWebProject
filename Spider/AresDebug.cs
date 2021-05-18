using Newtonsoft.Json;
using Spider.JsonDeserializeClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Spider
{
    class AresDebug
    {
        public static void ShowLimits()
        {
            WebRequest request = WebRequest.Create(StaticParameters.UrlLimit);
            WebResponse response = request.GetResponse();

            //Root splashInfo = null;
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

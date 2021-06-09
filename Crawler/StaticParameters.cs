using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Crawler
{
    internal class StaticParameters
    {
        public const string UrlLimit = "https://rest-app.net/api/info?login=chikchirick21@mail.ru&token=4850a3166296d3ea9318bb58b7f6225b";
        private const string UrlCategories = "https://rest-app.net/api/ads";
        private const string Login = "free2107@mail.ru";
        private const string Token = "bafda7c9982fb46ad760200719f5842d";

        public const int LimitProducts = 5;
        public static string UrlLoginToken
        {
            get
            {
                return $"{UrlCategories}?login={Login}&token={Token}";
            }
        }
    }
}

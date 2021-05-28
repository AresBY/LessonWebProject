using System;
using System.Collections.Generic;
using System.Text;

namespace LessonWebProject.Crawler.JsonDeserializeClasses
{
    public class ProductRoot
    {
        public string status { get; set; }
        public List<Product> data { get; set; }
        public override string ToString()
        {
            string outPut = string.Empty;
            foreach (var product in data)
            {
                outPut += $"{product.title} цена {product.price} описание {product.description} \n";
            }
            return outPut;
        }
    }
    public class Param
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Coords
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Product
    {
        public string Id { get; set; }
        public string url { get; set; }
        public string avito_id { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public string time { get; set; }
        public string @operator { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public string metro { get; set; }
        public string images { get; set; }
        public string description { get; set; }
        public List<Param> @params { get; set; }
        public string category_Id { get; set; }
        public string subcategory_Id { get; set; }
        public string region_Id { get; set; }
        public string city_Id { get; set; }
        public Coords coords { get; set; }
        public string images_big { get; set; }
        public string postfix { get; set; }
        public int @protected { get; set; }
        public List<object> other { get; set; }
    }
}

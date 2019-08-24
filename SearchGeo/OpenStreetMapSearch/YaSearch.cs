using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenStreetMapSearch.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OpenStreetMapSearch
{
    public class YaSearch
    {
        public string URI => "https://geocode-maps.yandex.ru/1.x";
        public string FORMAT => "json";
        public JsonSerializer SERIALIZER => JsonSerializer.Create();
        public string KEY => "7200b179-dea6-4091-ae36-54e83a0f751f";

        public List<YaSRoot> GetJsonObject(string stri)
        {
            List<YaSRoot> to_return;
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            StringBuilder str = new StringBuilder(URI);
            
            str.Append($"?geocode={stri}");
            str.Append($"&apikey={KEY}");
            str.Append($"&format={FORMAT}");

            Stream data = client.OpenRead(new Uri(str.ToString()));
            StreamReader reader = new StreamReader(data);

            var jo = SERIALIZER.Deserialize(new JsonTextReader(new StringReader(reader.ReadToEnd()))) as JObject;
            var ja = jo["response"]["GeoObjectCollection"]["featureMember"] as JArray;
            to_return = new List<YaSRoot>();
            foreach (var jo_in in ja)
            {
                var jo_point = jo_in["GeoObject"]["Point"]["pos"].Value<string>().Split(new String[] { " " }, StringSplitOptions.None);
                to_return.Add(new YaSRoot
                {
                    OtherInfo = jo_in,
                    Point = new YaPoint() { Long = jo_point[0], Lat = jo_point[1] }
                });
            }
            return to_return;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using OpenStreetMapSearch.Model;

namespace OpenStreetMapSearch
{
    public class OSMSearch
    {
        public string URI => "https://nominatim.openstreetmap.org/search/";
        public string FORMAT => "json";
        public JsonSerializer SERIALIZER => JsonSerializer.Create();

        public OSMSRoot[] GetJsonObject(List<string> strings)
        {

            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            StringBuilder str = new StringBuilder(URI);
            strings.ForEach(strin =>
            {
                str.Append(HttpUtility.UrlEncode(strin)).Append("/");
            });
            str.Remove(str.Length - 1, 1).Append($"?format={FORMAT}");

            Stream data = client.OpenRead(new Uri(str.ToString()));
            StreamReader reader = new StreamReader(data);
            
            return SERIALIZER.Deserialize<OSMSRoot[]>(new JsonTextReader(new StringReader(reader.ReadToEnd())));
        }
    }
}

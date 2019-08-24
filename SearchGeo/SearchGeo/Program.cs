using OpenStreetMapSearch;
using OpenStreetMapSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchGeo
{
    class Program
    {
        static void Main(string[] args)
        {
            //OSMSearch my_object = new OSMSearch();
            //OSMSRoot[] obj = my_object.GetJsonObject(new List<string> { "Санкт-Петербург", "Космонавтов", "38" });

            YaSearch my_object = new YaSearch();
            List<YaSRoot> obj = my_object.GetJsonObject("Санкт-Петербург Космонавтов 38");

        }
    }
}

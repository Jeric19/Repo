using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStreetMapSearch.Model
{
    public class YaSRoot
    {
        public dynamic OtherInfo { get; set; }
        public YaPoint Point { get; set; }
    }

    public class YaPoint
    {
        public string Long { get; set; }
        public string Lat { get; set; }
    }
}

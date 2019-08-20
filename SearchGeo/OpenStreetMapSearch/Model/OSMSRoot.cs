using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStreetMapSearch.Model
{
    public class OSMSRoot
    {
        public string place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public string osm_id { get; set; }
        public dynamic boundingbox { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string display_name { get; set; }

        //public string class { get; set; }

        public string type { get; set; }
        public string importance { get; set; }
        public string icon { get; set; }
    }
}

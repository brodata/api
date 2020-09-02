using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    public class ISO3166
    {
        public string name { get; set; }
        public string alpha_2 { get; set; }
        public string alpha_3 { get; set; }
        public string country_code { get; set; }
        public string iso_3166_2 { get; set; }
        public string region { get; set; }
        public string sub_region { get; set; }
        public string intermediate_region { get; set; }
        public string region_code { get; set; }
        public string sub_region_code { get; set; }
        public string intermediate_region_code { get; set; }
        public string cctld { get; set; }
        public List<string> imgUrls { get; set; }
    }
}

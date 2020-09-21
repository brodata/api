using System.ComponentModel.DataAnnotations.Schema;

namespace BroData.API.Models.v0
{
    [Table("dataset_iso3166")]
    public class ISO3166 : IISO3166
    {
        public string name { get; set; }
        public string alpha_2 { get; set; }
        public string alpha_3 { get; set; }
        public int country_code { get; set; }
        public string iso_3166_2 { get; set; }
        public string region { get; set; }
        public string sub_region { get; set; }
        public string intermediate_region { get; set; }
        public int region_code { get; set; }
        public int sub_region_code { get; set; }
        public int intermediate_region_code { get; set; }
        public string cctld { get; set; }
        public string imgurls { get; set; }
    }

    public interface IISO3166
    {
        string name { get; set; }
        string alpha_2 { get; set; }
        string alpha_3 { get; set; }
        int country_code { get; set; }
        string iso_3166_2 { get; set; }
        string region { get; set; }
        string sub_region { get; set; }
        string intermediate_region { get; set; }
        int region_code { get; set; }
        int sub_region_code { get; set; }
        int intermediate_region_code { get; set; }
        string cctld { get; set; }
        string imgurls { get; set; }
    }
}

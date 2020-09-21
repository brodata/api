using System.ComponentModel.DataAnnotations.Schema;

namespace BroData.API.Models.v0
{
    [Table("dataset_view_us_cities")]
    public class City : ICity
    {
        public int id { get; set; }
        public string state_code { get; set; }
        public string county { get; set; }
        public string city { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }

    public interface ICity
    {
        int id { get; set; }
        string state_code { get; set; }
        string county { get; set; }
        string city { get; set; }
        float latitude { get; set; }
        float longitude { get; set; }
    }
}

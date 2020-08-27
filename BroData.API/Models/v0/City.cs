using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    [Table("dataset_view_us_cities")]
    public class City : ICity
    {
        public int id { get; set; }
        [Column("state_code")]
        public string code { get; set; }
        public string county { get; set; }
        public string city { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }

    public interface ICity
    {
        int id { get; set; }
        string code { get; set; }
        string county { get; set; }
        string city { get; set; }
        float latitude { get; set; }
        float longitude { get; set; }
    }
}

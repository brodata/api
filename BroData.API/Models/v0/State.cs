using System.ComponentModel.DataAnnotations.Schema;

namespace BroData.API.Models.v0
{
    [Table("dataset_us_states")]
    public class State : IState
    {
        public int id { get; set; }
        [Column("state_code")]
        public string code { get; set; }
        [Column("state_name")]
        public string name { get; set; }
    }
    public interface IState
    {
        int id { get; set; }
        string code { get; set; }
        string name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace BroData.API.Models.v0
{
    [Table("dataset_names")]
    public class Name : IName
    {
        public string name { get; set; }
    }

    public interface IName
    {
        string name { get; set; }
    }
}
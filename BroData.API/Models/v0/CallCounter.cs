using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroData.API.Models.v0
{
    [Table("statistics_get_call_counter")]
    public class CallCounter : ICallCounter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int id { get; set; }
        public string get_name { get; set; }
        public long count { get; set; }
    }

    public interface ICallCounter
    {
        string get_name { get; set; }
        long count { get; set; }
    }
}

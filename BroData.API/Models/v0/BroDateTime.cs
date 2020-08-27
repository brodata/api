using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    public class BroDateTime : IBroDateTime
    {
        public string bro_datetime { get; set; }

        public BroDateTime(string format = null) => bro_datetime = DateTime.UtcNow.ToString(format);
    }

    public interface IBroDateTime { string bro_datetime { get; set; } }
}

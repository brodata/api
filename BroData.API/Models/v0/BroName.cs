using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    public class BroName : IBroName
    {
        public object bro_name { get; set; }
        public BroName(object name) => bro_name = name;
    }

    public interface IBroName { object bro_name { get; set; } }
}

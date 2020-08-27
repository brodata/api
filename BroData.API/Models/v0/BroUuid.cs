using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    public class BroUuid : IBroUuid
    {
        public object bro_guid { get; set; }
        public BroUuid(object _guid) => bro_guid = _guid;
    }

    public interface IBroUuid { object bro_guid { get; set; } }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    
    public class BroTelephon : IBroTelephon
    {
        public object bro_telephone { get; set; }
        public BroTelephon(object telephone) => bro_telephone = telephone;
    }

    public interface IBroTelephon { object bro_telephone { get; set; } }
}

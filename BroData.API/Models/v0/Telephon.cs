using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    
    public class Telephon : ITelephon
    {
        public object telephone { get; set; }
        public Telephon(object _telephone) => telephone = _telephone;
    }

    public interface ITelephon { object telephone { get; set; } }
}

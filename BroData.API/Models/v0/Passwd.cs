using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    public class Passwd : IPasswd
    {
        public object passwd { get; set; }
        public Passwd(object _passwd) => passwd = _passwd;
    }
    
    public interface IPasswd { object passwd { get; set; } }
}

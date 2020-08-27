using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    public class BroPasswd : IBroPasswd
    {
        public object bro_passwd { get; set; }
        public BroPasswd(object passwd) => bro_passwd = passwd;
    }
    
    public interface IBroPasswd { object bro_passwd { get; set; } }
}

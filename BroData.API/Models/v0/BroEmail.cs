using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    public class BroEmail : IBroEmail
    {
        public object bro_email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public BroEmail(object email) => bro_email = email;
    }
    public interface IBroEmail
    {
        object bro_email { get; set; }
    }
}

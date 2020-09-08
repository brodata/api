using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    public class Email : IEmail
    {
        public string name { get; set; }
    }

    public interface IEmail
    {
        string name { get; set; }
    }
}

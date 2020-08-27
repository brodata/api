using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    public class Error : IError
    {
        public string error { get; set; }

        public Error(string _message) => error = _message;
    }

    public interface IError { string error { get; set; } }
}

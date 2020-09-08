using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Models.v0
{
    public class Surname : ISurname
    {
        public string surname { get; set; }
    }

    public interface ISurname
    {
        string surname { get; set; }
    }
}

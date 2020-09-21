using System;

namespace BroData.API.Models.v0
{
    public class GenDateTime : IBroDateTime
    {
        public string datetime { get; set; }

        public GenDateTime(string format = null) => datetime = DateTime.UtcNow.ToString(format);
    }

    public interface IBroDateTime { string datetime { get; set; } }
}

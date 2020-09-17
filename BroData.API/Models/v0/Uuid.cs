using System;

namespace BroData.API.Models.v0
{
    public class Uuid : IUuid
    {
        public Guid guid { get; set; }
    }

    public interface IUuid { Guid guid { get; set; } }
}

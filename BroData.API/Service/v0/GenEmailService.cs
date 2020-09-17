using BroData.API.Brokers;
using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BroData.API.Service.v0
{
    public class GenEmailService : IGenEmailService
    {
        private readonly StringBuilder StringBuilder = new StringBuilder();
        private readonly StorageBroker _context;
        public GenEmailService(StorageBroker context) => _context = context;

        public IEmail Get()
        {
            IName tmp = _context.Names.FromSqlRaw("select * from dataset_names ORDER BY random() LIMIT 1").FirstAsync().Result;
            StringBuilder.Append(tmp.name.ToLower());
            StringBuilder.Append("@example.lan");
            return new Email { name = StringBuilder.ToString() };
        }
    }

    public interface IGenEmailService
    {
        IEmail Get();
    }
}

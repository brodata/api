using BroData.API.Brokers;
using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class GenEmailService : IGenEmailService
    {
        private StringBuilder StringBuilder = new StringBuilder();
        private readonly StorageBroker _context;
        public GenEmailService(StorageBroker context) => _context = context;

        public IEmail Get()
        {
            IQueryable<Name> tmp = _context.Names.FromSqlRaw("select * from dataset_names ORDER BY random() LIMIT 1");
            StringBuilder.Append(tmp.First().name);
            StringBuilder.Append("@example.lan");
            return new Email{ name = StringBuilder.ToString()};   
        }
    }

    public interface IGenEmailService
    {
        IEmail Get();
    }
}

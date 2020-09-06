using BroData.API.Brokers;
using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class NameService : INameService
    {
        private readonly StorageBroker _context;

        public NameService(StorageBroker context) => _context = context;

        IEnumerable<IName> INameService.GetRandom()
        {
            //return _context.Names.AsNoTracking().Where(x => true).ToList();
            return _context.Names.FromSqlRaw("select * from dataset_names ORDER BY random() LIMIT 1");
        }
    }

    public interface INameService
    {
        IEnumerable<IName> GetRandom();
    }
}

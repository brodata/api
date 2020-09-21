using BroData.API.Brokers;
using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class NameService : INameService
    {
        private readonly StorageBroker _context;

        public NameService(StorageBroker context) => _context = context;

        async Task<IName> INameService.GetRandom()
        {
            //return _context.Names.AsNoTracking().Where(x => true).ToList();
            return await _context.Names.FromSqlRaw("select * from dataset_names ORDER BY random() LIMIT 1").FirstAsync();
        }
    }

    public interface INameService
    {
        Task<IName> GetRandom();
    }
}

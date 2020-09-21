using BroData.API.Brokers;
using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class SurnameService : ISurnameService
    {
        private readonly StorageBroker _context;

        public SurnameService(StorageBroker context) => _context = context;

        async Task<ISurname> ISurnameService.GetRandom()
        {
            //return _context.Names.AsNoTracking().Where(x => true).ToList();
            return await _context.Surnames.FromSqlRaw("select surname from dataset_surnames ORDER BY random() LIMIT 1").FirstAsync();
        }

        async Task<ISurname> ISurnameService.GetByCountry(string country)
        {
            //return _context.Names.AsNoTracking().Where(x => true).ToList();
            return await _context.Surnames.FromSqlRaw($"select surname from dataset_surnames " +
                $"where country = '{country.ToLower()}' " +
                $"ORDER BY random() LIMIT 1").FirstAsync();
        }
    }
    public interface ISurnameService
    {
        Task<ISurname> GetRandom();
        Task<ISurname> GetByCountry(string country);
    }
}

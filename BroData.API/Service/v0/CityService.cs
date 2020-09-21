using BroData.API.Brokers;
using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class CityService : ICityService
    {
        private readonly StorageBroker _context;
        public CityService(StorageBroker context) => _context = context;

        public async Task<IEnumerable<ICity>> GetAll()
        {
            return await _context.Cities.AsNoTracking().Where(x => true).ToListAsync();
        }

        public async Task<ICity> GetByID(int id)
        {
            return await _context.Cities.AsNoTracking().Where(x => x.id == id).FirstAsync();
        }

        public async Task<IEnumerable<ICity>> GetByState(string state)
        {
            return await _context.Cities.AsNoTracking().Where(x => x.state_code == state.ToUpper()).ToListAsync();
        }
    }

    public interface ICityService
    {
        Task<IEnumerable<ICity>> GetAll();
        Task<IEnumerable<ICity>> GetByState(string state);
        Task<ICity> GetByID(int id);
    }
}

using BroData.API.Brokers;
using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class CityService : ICityService
    {
        private readonly StorageBroker _context;
        public CityService(StorageBroker context) => _context = context;
        IEnumerable<ICity> ICityService.GetAll()
        {
            return _context.Cities.AsNoTracking().Where(x => true).ToList();
        }

        async Task<IEnumerable<ICity>> ICityService.GetByState(string state)
        {
            return await _context.Cities.AsNoTracking().Where(x => x.code == state.ToUpper()).ToListAsync();
        }
    }

    public interface ICityService
    {
        IEnumerable<ICity> GetAll();
        Task<IEnumerable<ICity>> GetByState(string state);
    }
}

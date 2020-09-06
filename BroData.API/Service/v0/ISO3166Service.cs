using BroData.API.Brokers;
using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class ISO3166Service : IISO3166Service
    {
        private readonly StorageBroker _context;

        public ISO3166Service(StorageBroker context) => 
            _context = context;

        public async Task<IISO3166> GetByAlpha2(string alpha2) =>
            await _context.iSO3166s.Where(x => x.alpha_2 == alpha2).SingleAsync();

        public async Task<IISO3166> GetByAlpha3(string alpha3) =>
             await _context.iSO3166s.Where(x => x.alpha_2 == alpha3).SingleAsync();

        IEnumerable<IISO3166> IISO3166Service.GetAll() => _context.iSO3166s.Where(x => true).ToList();
    }

    public interface IISO3166Service
    {
        IEnumerable<IISO3166> GetAll();
        Task<IISO3166> GetByAlpha2(string alpha2);
        Task<IISO3166> GetByAlpha3(string alpha3);
    }
}

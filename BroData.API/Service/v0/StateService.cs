using BroData.API.Brokers;
using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class StateService : IStateService
    {
        private readonly StorageBroker _context;
        public StateService(StorageBroker context) => _context = context;

        public async Task<IEnumerable<IState>> GetAll()
        {
            return await _context.States.AsNoTracking().Where(x => true).ToListAsync();
        }
    }
    public interface IStateService
    {
        Task<IEnumerable<IState>> GetAll();
    }
}

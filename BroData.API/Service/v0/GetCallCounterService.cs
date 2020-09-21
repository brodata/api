using BroData.API.Brokers;
using BroData.API.Models.v0;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class GetCallCounterService : IGetCallCounterService
    {
        private readonly StorageBroker _context;
        public GetCallCounterService(StorageBroker context) => _context = context;

        public async Task<IEnumerable<ICallCounter>> GetAllAsync()
        {
            return await _context.callCounters.Where(x => true).ToListAsync();
        }

        public async Task<ICallCounter> GetByFunctionName(string f_name)
        {
            return await _context.callCounters.Where(x => x.get_name == f_name.ToLower()).SingleOrDefaultAsync();
        }

        public async Task<bool> UpdateCounter(HttpContext httpContext)
        {
            try
            {
                string f_name = httpContext.Request.Path.ToString().Split('/')[2];
                ICallCounter callCounter = await GetByFunctionName(f_name);
                if (callCounter == null)
                {
                    callCounter = new CallCounter { get_name = f_name.ToLower(), count = 1 };
                    _context.callCounters.Add((CallCounter)callCounter);
                }
                else
                {
                    callCounter.count++;
                    _context.callCounters.Update((CallCounter)callCounter);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
    public interface IGetCallCounterService
    {
        Task<IEnumerable<ICallCounter>> GetAllAsync();
        Task<ICallCounter> GetByFunctionName(string f_name);
        Task<bool> UpdateCounter(HttpContext f_name);
    }
}

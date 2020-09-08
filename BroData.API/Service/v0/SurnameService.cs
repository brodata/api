using BroData.API.Brokers;
using BroData.API.Models.v0;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Service.v0
{
    public class SurnameService : ISurnameService
    {
        private readonly StorageBroker _context;

        public SurnameService(StorageBroker context) => _context = context;

        ISurname ISurnameService.GetRandom()
        {
            //return _context.Names.AsNoTracking().Where(x => true).ToList();
            return _context.Surnames.FromSqlRaw("select surname from dataset_surnames ORDER BY random() LIMIT 1").First();
        }

        ISurname ISurnameService.GetByCountry(string country)
        {
            //return _context.Names.AsNoTracking().Where(x => true).ToList();
            return _context.Surnames.FromSqlRaw($"select surname from dataset_surnames " +
                $"where country = '{country.ToLower()}' " +
                $"ORDER BY random() LIMIT 1").First();
        }
    }
    public interface ISurnameService
    {
        ISurname GetRandom();
        ISurname GetByCountry(string country);
    }
}

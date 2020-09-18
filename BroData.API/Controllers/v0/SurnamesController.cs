using BroData.API.Data;
using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class SurnamesController : ControllerBase
    {
        

        /// <summary>
        /// Gets random the of Surname.
        /// </summary>
        /// <returns>The of Surname</returns>
        [HttpGet]
        public ISurname Get()
        {
            return SurnamesRepo.GetRandom();
        }

        [HttpGet("{country}")]
        public ISurname GetByCountry(string country)
        {
            return SurnamesRepo.GetGetByCountry(country);
        }
    }
}

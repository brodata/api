using BroData.API.Data;
using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {


        /// <summary>
        /// Gets the list of all US Cities.
        /// </summary>
        /// <returns>The list of City.</returns>
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<ICity> GetAll() => CitiesRepo.GetAll();

        /// <summary>
        /// Gets by State the list of all US Cities.
        /// </summary>
        /// <returns>The list of City.</returns>
        [HttpGet("{state}")]
        public IEnumerable<ICity> GetByState(string state)
        {
            return CitiesRepo.GetAll().Where(x => x.state_code == state);
        }
        /// <summary>
        /// Gets by ID the of US Cities.
        /// </summary>
        /// <returns>The item of City.</returns>
        [HttpGet("{id:int}")]
        public ICity GetByID(int id)
        {
            return CitiesRepo.GetAll().Where(x => x.id == id).First();
        }
    }
}

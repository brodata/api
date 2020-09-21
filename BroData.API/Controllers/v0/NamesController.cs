using BroData.API.Data;
using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        

        /// <summary>
        /// Gets random the of Name.
        /// </summary>
        /// <returns>The of Name</returns>
        [HttpGet]
        public IEnumerable<IName> GetAll()
        {
            return NamesRepo.GetAll();
        }
    }
}

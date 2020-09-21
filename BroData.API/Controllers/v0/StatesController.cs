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
    public class StatesController : ControllerBase
    {


        [HttpGet]
        public IEnumerable<IState> GetAll() => StatesRepo.GetAll();
    }
}

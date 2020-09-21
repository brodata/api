using BroData.API.Datasets;
using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class ISO3166Controller : ControllerBase
    {
        
        //private readonly IGetCallCounterService _getCallCounterService;

        /// <summary>
        /// Gets IISO3166 dataset.
        /// </summary>
        /// <returns>The list of IISO3166</returns>
        [HttpGet]
        public IEnumerable<IISO3166> GetAll()
        {
            //await _getCallCounterService.UpdateCounter(HttpContext);
            return ISO3166Repo.GetAll();
            //return await Task.FromResult(Ok(new Response<IISO3166>(await _i3166Service.GetAll())));
        }
    }
}

using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class TelephonesController : ControllerBase
    {
        private readonly IGenTelephonService _broTelephonService;
        private readonly IGetCallCounterService _getCallCounterService;

        public TelephonesController(IGenTelephonService broPasswdService, IGetCallCounterService getCallCounterService)
        {
            _broTelephonService = broPasswdService;
            _getCallCounterService = getCallCounterService;
        }
        /// <summary>
        /// Gets random generated Telephon.
        /// </summary>
        /// <returns>Telephon</returns>
        [HttpGet]
        public async Task<IActionResult> GetTelephonAsync()
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return Ok(new Response<ITelephon>(_broTelephonService.Get()));
        }
        /// <summary>
        /// Gets random generated the list of Telephon.
        /// </summary>
        /// <returns>The list of Telephon</returns>   
        [HttpGet("{count}")]
        public async Task<IActionResult> GetTelephonAsync(int count)
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            if (count > 100)
                return StatusCode(400, new Error("Max count: 100"));
            return Ok(new Response<ITelephon>(_broTelephonService.Get(count: count)));
        }
    }
}

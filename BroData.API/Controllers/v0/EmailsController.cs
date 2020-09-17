using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IGenEmailService _genEmailService;
        private readonly IGetCallCounterService _getCallCounterService;
        public EmailsController(IGenEmailService genEmailService, IGetCallCounterService getCallCounterService)
        {
            _genEmailService = genEmailService;
            _getCallCounterService = getCallCounterService;

        }
        /// <summary>
        /// Gets random generated Email address.
        /// </summary>
        /// <returns>Email</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return Ok(new Response<IEmail>(_genEmailService.Get()));
        }
    }
}

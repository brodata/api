using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class DateTimeController : ControllerBase
    {
        private readonly IGetCallCounterService _getCallCounterService;

        public DateTimeController(IGetCallCounterService getCallCounterService)
            => _getCallCounterService = getCallCounterService;

        /// <summary>
        /// Gets DateTime.
        /// </summary>
        /// <returns>DateTime</returns>
        [HttpGet]
        public async Task<IActionResult> GetDateTimeAsync()
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return Ok(new Response<IBroDateTime>(new GenDateTime()));
        }

        /// <summary>
        /// Gets DateTime custom of format.
        /// </summary>
        /// <returns>DateTime</returns>
        [HttpGet("{format}")]
        public async Task<IActionResult> GetDateTimeWithFormatAsync(string format)
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            string[] allow_format = { "d", "D", "f", "F", "g", "G", "m", "r", "s", "t", "T", "u", "U", "y" };
            foreach (string tmp in allow_format)
                if (tmp == format)
                    return Ok(new Response<IBroDateTime>(new GenDateTime(format)));
            return StatusCode(400, new Error("Format not valid!"));
        }
    }
}

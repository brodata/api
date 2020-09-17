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
        private readonly ISurnameService _surnameService;
        private readonly IGetCallCounterService _getCallCounterService;
        public SurnamesController(ISurnameService surnameService, IGetCallCounterService getCallCounterService)
        {
            _surnameService = surnameService;
            _getCallCounterService = getCallCounterService;
        }

        /// <summary>
        /// Gets random the of Surname.
        /// </summary>
        /// <returns>The of Surname</returns>
        [HttpGet]
        async public Task<IActionResult> Get()
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return await Task.FromResult(Ok(new Response<ISurname>(await _surnameService.GetRandom())));
        }

        [HttpGet("{country}")]
        async public Task<IActionResult> GetByCountry(string country)
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return await Task.FromResult(Ok(new Response<ISurname>(await _surnameService.GetByCountry(country))));
        }
    }
}

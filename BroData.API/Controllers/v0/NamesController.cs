using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        private readonly INameService _broNameService;
        private readonly IGetCallCounterService _getCallCounterService;

        public NamesController(INameService broNameService, IGetCallCounterService getCallCounterService)
        {
            _broNameService = broNameService;
            _getCallCounterService = getCallCounterService;
        }

        /// <summary>
        /// Gets random the of Name.
        /// </summary>
        /// <returns>The of Name</returns>
        [HttpGet]
        async public Task<IActionResult> GetDateTime()
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return await Task.FromResult(Ok(new Response<IName>(await _broNameService.GetRandom())));
        }
    }
}

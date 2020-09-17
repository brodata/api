using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateService _stateService;
        private readonly IGetCallCounterService _getCallCounterService;

        public StatesController(IStateService stateService, IGetCallCounterService getCallCounterService)
        {
            _stateService = stateService;
            _getCallCounterService = getCallCounterService;
        }

        [HttpGet]
        async public Task<IActionResult> GetAll()
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return await Task.FromResult(Ok(new Response<IState>(await _stateService.GetAll())));
        }
    }
}

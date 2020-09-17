using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IGetCallCounterService _getCallCounterService;

        public CitiesController(ICityService cityService, IGetCallCounterService getCallCounterService)
        {
            _cityService = cityService;
            _getCallCounterService = getCallCounterService;
        }

        /// <summary>
        /// Gets the list of all US Cities.
        /// </summary>
        /// <returns>The list of City.</returns>
        // GET: api/Employee
        [HttpGet]
        async public Task<IActionResult> GetAll()
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return await Task.FromResult(Ok(new Response<ICity>(await _cityService.GetAll())));
        }
        /// <summary>
        /// Gets by State the list of all US Cities.
        /// </summary>
        /// <returns>The list of City.</returns>
        [HttpGet("{state}")]
        async public Task<IActionResult> GetByState(string state)
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return await Task.FromResult(Ok(new Response<ICity>(await _cityService.GetByState(state))));
        }
        /// <summary>
        /// Gets by ID the of US Cities.
        /// </summary>
        /// <returns>The item of City.</returns>
        [HttpGet("{id:int}")]
        async public Task<IActionResult> GetByID(int id)
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return await Task.FromResult(Ok(new Response<ICity>(await _cityService.GetByID(id))));
        }
    }
}

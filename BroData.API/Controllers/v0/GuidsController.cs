using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class GuidsController : ControllerBase
    {
        private readonly IGetCallCounterService _getCallCounterService;
        public GuidsController(IGetCallCounterService getCallCounterService)
        {
            _getCallCounterService = getCallCounterService;
        }
        /// <summary>
        /// Gets random generated GUID.
        /// </summary>
        /// <returns>GUID</returns>
        [HttpGet]
        async public Task<IActionResult> GetUuuid()
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return await Task.FromResult(Ok(
                    new Response<IUuid>(
                        new Uuid { guid = Guid.NewGuid() })));
        }
        /// <summary>
        /// Gets random generated the list of GUID.
        /// </summary>
        /// <returns>The list of GUID</returns>
        [HttpGet("{count:int}")]
        public async Task<IActionResult> GetUuuidAsync(int count)
        {
            await _getCallCounterService.UpdateCounter(HttpContext);

            if (count > 100)
                return StatusCode(400, new Error("Count limit: 100"));
            List<IUuid> massiv = new List<IUuid>();
            for (int i = 0; i < count; i++)
                massiv.Add(new Uuid { guid = Guid.NewGuid() });
            return Ok(new Response<IEnumerable<IUuid>>(massiv));
        }
    }
}

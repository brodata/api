﻿using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class ISO3166Controller : ControllerBase
    {
        private readonly IISO3166Service _i3166Service;
        private readonly IGetCallCounterService _getCallCounterService;

        public ISO3166Controller(IISO3166Service i3166Service, IGetCallCounterService getCallCounterService)
        {
            _i3166Service = i3166Service;
            _getCallCounterService = getCallCounterService;
        }

        /// <summary>
        /// Gets IISO3166 dataset.
        /// </summary>
        /// <returns>The list of IISO3166</returns>
        [HttpGet]
        async public Task<IActionResult> GetAll()
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            return await Task.FromResult(Ok(new Response<IISO3166>(await _i3166Service.GetAll())));
        }
    }
}

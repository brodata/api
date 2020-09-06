using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BroData.API.Controllers.v0
{
    [Route("api/[controller]")]
    [ApiController]
    public class ISO3166Controller : ControllerBase
    {
        private readonly IISO3166Service _i3166Service;

        public ISO3166Controller(IISO3166Service i3166Service) => _i3166Service = i3166Service;

        [HttpGet]
        async public Task<IActionResult> GetAll()
        {
            return await Task.FromResult(Ok(new Response<IISO3166>(_i3166Service.GetAll())));
        }
    }
}

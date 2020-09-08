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
    public class GenTelephonController : ControllerBase
    {
        private readonly IGenTelephonService _broTelephonService;

        public GenTelephonController(IGenTelephonService broPasswdService) => _broTelephonService = broPasswdService;

        [HttpGet]
        public IActionResult GetTelephon()
        {
            return Ok(new Response<ITelephon>(_broTelephonService.Get()));
        }

        [HttpGet("{len}")]
        public IActionResult GetTelephon(int len)
        {
            if (len > 1024)
                return StatusCode(400, new Error("Max len: 1024"));
            return Ok(new Response<IPasswd>(_broTelephonService.Get(count: len)));
        }
    }
}

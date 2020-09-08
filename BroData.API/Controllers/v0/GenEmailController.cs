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
    public class GenEmailController : ControllerBase
    {
        private readonly IGenEmailService _genEmailService;
        public GenEmailController(IGenEmailService genEmailService) => _genEmailService = genEmailService;

        [HttpGet]
        public IActionResult Get() => Ok(new Response<IEmail>(_genEmailService.Get()));
    }
}

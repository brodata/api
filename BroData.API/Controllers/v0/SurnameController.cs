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
    public class SurnameController : ControllerBase
    {
        private readonly ISurnameService _surnameService;
        public SurnameController(ISurnameService surnameService) => _surnameService = surnameService;

        [HttpGet]
        async public Task<IActionResult> Get()
        {
            return await Task.FromResult(Ok(new Response<ISurname>(_surnameService.GetRandom())));
        }

        [HttpGet("{country}")]
        async public Task<IActionResult> GetByCountry(string country)
        {
            return await Task.FromResult(Ok(new Response<ISurname>(_surnameService.GetByCountry(country))));
        }
    }
}

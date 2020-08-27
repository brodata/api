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
    public class BroNameController : ControllerBase
    {
        private readonly IBroNameService _broNameService;

        public BroNameController(IBroNameService broNameService) => _broNameService = broNameService;

        [HttpGet]
        async public Task<IActionResult> GetDateTime()
        {
            return await Task.FromResult(Ok(new Response<IBroName>(_broNameService.Name)));
        }
    }
}

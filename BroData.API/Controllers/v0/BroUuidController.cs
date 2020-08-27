using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BroData.API.Models.v0;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BroData.API.Controllers.v0
{
    [Route("api/[controller]")]
    [ApiController]
    public class BroUuidController : ControllerBase
    {
        [HttpGet]
        async public Task<IActionResult> GetUuuid()
        {
            return await Task.FromResult(Ok(
                    new Response<IBroUuid>(
                        new BroUuid(Guid.NewGuid()))));
        }

        [HttpGet("{count:int}")]
        public IActionResult GetUuuid(int count)
        {
            if (count > 100000)
                return StatusCode(400, new Error("Count limit: 100000"));
            List <Guid> massiv = new List<Guid>();
            for (int i = 0; i < count; i++)
                massiv.Add(Guid.NewGuid());
            return Ok(new Response<IBroUuid>(new BroUuid(massiv)));
        }
    }
}

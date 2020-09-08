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
    public class GenDateTimeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDateTime()
        {
            return Ok(new Response<IBroDateTime>(new GenDateTime()));
        }

        [HttpGet("{format}")]
        public IActionResult GetDateTimeWithFormat(string format)
        {
            string[] allow_format = { "d", "D", "f", "F", "g", "G", "m", "r", "s", "t", "T", "u", "U", "y" };
            foreach(string tmp in allow_format)
                if (tmp == format)
                    return Ok(new Response<IBroDateTime>(new GenDateTime(format)));
            return StatusCode(400, new Error("Format not valid!"));
        }
    }
}

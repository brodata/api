using System;
using System.Threading.Tasks;
using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;

namespace BroData.API.Controllers.v0
{
    [Route("api/[controller]")]
    [ApiController]
    public class BroPasswdController : ControllerBase 
    {
        private readonly IBroPasswdService _broPasswdService;

        public BroPasswdController(IBroPasswdService broPasswdService) => _broPasswdService = broPasswdService;

        [HttpGet]
        public IActionResult GetPasswd()
        {
            return Ok(new Response<IBroPasswd>(_broPasswdService.Get(1, 12, new int[] { 1, 1, 1, 1 })));
        }

        [HttpGet("{len}")]
        public IActionResult GetPasswd(int len)
        {
            if (len > 1024)
                return StatusCode(400, new Error("Max len: 1024"));
            return Ok(new Response<IBroPasswd>(_broPasswdService.Get(1, len, new int[] { 1, 1, 1, 1 })));
        }

        [HttpGet("{len}:{bitmask}")]
        public IActionResult GetPasswd(int len, string bitmask)
        {
            if (len > 1024)
                return StatusCode(400, new Error("Max len: 1024"));
            if (bitmask.Length > 4)
                return StatusCode(400, new Error("Bitmask size 4 bits only!"));
            int[] bin_mask = new int[4];
            for (int i = 0; i < bitmask.Length; i++)
                bin_mask[i] = bitmask[i] - '0';
            return Ok(new Response<IBroPasswd>(_broPasswdService.Get(1, len, bin_mask)));
        }

        [HttpGet("{len}:{bitmask}/{count}")]
        public IActionResult GetPasswd(int len, string bitmask, int count)
        {
            if (!string.IsNullOrWhiteSpace(bitmask))
            {

                

                if (len > 1024)
                    return StatusCode(400, new Error("Max len: 1024"));
                if (bitmask.Length > 4)
                    return StatusCode(400, new Error("Bitmask size 4 bits only!"));
                if (count > 1000)
                    return StatusCode(400, new Error("Max passwds count: 1000"));
                int[] bin_mask = new int[4];
                for (int i = 0; i < bitmask.Length; i++)
                    bin_mask[i] = bitmask[i] - '0';

                int chech_mask = 0;
                if (bin_mask.Length != 4)
                    return StatusCode(400, new Error("Mask not valid!"));
                // throw new ArgumentException("Mask not valid!");
                foreach (int tmp in bin_mask)
                    if (tmp == 0 || tmp == 1)
                        chech_mask += tmp;
                    else
                        return StatusCode(400, new Error("Mask not valid!"));
                //throw new ArgumentException("Mask not valid!");
                if (chech_mask == 0)
                    return StatusCode(400, new Error("Mask not valid!"));
                //throw new ArgumentException("Mask not valid!");
                return Ok(new Response<IBroPasswd>(_broPasswdService.Get(count, len, bin_mask)));
            }
            else
                return StatusCode(400, new Error("Bitmask don't have value"));
                //throw new ArgumentNullException(nameof(bitmask), "Bitmask don't have value");
            

            
        }
    }
}

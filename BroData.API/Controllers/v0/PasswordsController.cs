using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly IGenPasswdService _genPasswdService;
        private readonly IGetCallCounterService _getCallCounterService;

        public PasswordsController(IGenPasswdService broPasswdService, IGetCallCounterService getCallCounterService)
        {
            _genPasswdService = broPasswdService;
            _getCallCounterService = getCallCounterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPasswdAsync()
        {

            await _getCallCounterService.UpdateCounter(HttpContext);
            return Ok(new Response<IPassword>(_genPasswdService.Get(16, new int[] { 1, 1, 1, 1 })));
        }

        [HttpGet("{len}")]
        public async Task<IActionResult> GetPasswdAsync(int len)
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            if (len > 1024)
                return StatusCode(400, new Error("Max len: 1024"));
            return Ok(new Response<IPassword>(_genPasswdService.Get(len, new int[] { 1, 1, 1, 1 })));
        }

        [HttpGet("{len}:{bitmask}")]
        public async Task<IActionResult> GetPasswdAsync(int len, string bitmask)
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            if (len > 1024)
                return StatusCode(400, new Error("Max len: 1024"));
            if (bitmask.Length > 4)
                return StatusCode(400, new Error("Bitmask size 4 bits only!"));
            int[] bin_mask = new int[4];
            for (int i = 0; i < bitmask.Length; i++)
                bin_mask[i] = bitmask[i] - '0';
            return Ok(new Response<IPassword>(_genPasswdService.Get(len, bin_mask)));
        }

        [HttpGet("{len}:{bitmask}/{count}")]
        public async Task<IActionResult> GetPasswdAsync(int len, string bitmask, int count)
        {
            await _getCallCounterService.UpdateCounter(HttpContext);
            if (!string.IsNullOrWhiteSpace(bitmask))
            {



                if (len > 1024)
                    return StatusCode(400, new Error("Max len: 1024"));
                if (bitmask.Length > 4)
                    return StatusCode(400, new Error("Bitmask size 4 bits only!"));
                if (count > 100)
                    return StatusCode(400, new Error("Max passwds count: 100"));
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
                return Ok(new Response<IEnumerable<IPassword>>(_genPasswdService.Get(count, len, bin_mask)));
            }
            else
                return StatusCode(400, new Error("Bitmask don't have value"));
            //throw new ArgumentNullException(nameof(bitmask), "Bitmask don't have value");



        }
    }
}

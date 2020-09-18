using BroData.API.Models.v0;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BroData.API.Controllers.v0
{
    [Route("v0/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IGenEmailService _genEmailService;
        public EmailsController(IGenEmailService genEmailService)
        {
            _genEmailService = genEmailService;

        }
        /// <summary>
        /// Gets random generated Email address.
        /// </summary>
        /// <returns>Email</returns>
        [HttpGet]
        public IEmail Get()
        {
            return _genEmailService.Get();
        }
    }
}

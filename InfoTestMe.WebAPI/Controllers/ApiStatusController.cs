using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTestMe.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiStatusController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;

        public ApiStatusController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> CheckApi()
        {
            return Ok("Server is ready " + DateTime.Now);
        }
    }
}

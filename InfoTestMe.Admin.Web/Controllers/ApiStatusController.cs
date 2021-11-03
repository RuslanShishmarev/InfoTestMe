using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiStatusController : ControllerBase
    {

        private readonly ILogger<ApiStatusController> _logger;

        public ApiStatusController(ILogger<ApiStatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet("status")]
        public ActionResult<string> CheckApi()
        {
            return Ok("Server is ready " + DateTime.Now);
        }
    }
}

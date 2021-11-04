using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Admin.Web.Services;
using InfoTestMe.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InfoTestMe.Admin.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly TestService _testService;
        public TestsController(InfoTestMeDataContext db)
        {
            _testService = new TestService(db);
        }
        // POST api/<TestsController>
        [HttpPost]
        public IActionResult CreateTest([FromBody] TestDTO testDTO)
        {
            if(testDTO != null)
            {
                bool result = _testService.Create(testDTO);
                return result ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        
    }
}

using InfoTestMe.Admin.Web.Models;
using InfoTestMe.Admin.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerCourse.Api.Models;

namespace InfoTestMe.Admin.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly UsersService _userService;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
            _userService = new UsersService();
        }

        [HttpPost("token")]
        public IActionResult GetToken()
        {
            var userData = _userService.GetUserLoginPassFromBasicAuth(Request);
            var login = userData.userName;
            var pass = userData.userPassword;
            var identity = _userService.GetIdentity(login, pass);

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.AddMinutes(AuthOptions.LIFETIME),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new AuthToken
            {
                Token = encodedJwt,
                UserLogin = identity.Name
            };

            return Ok(response);
        }

        [HttpPost("register/user")]
        public IActionResult CheckInForUser([FromBody] object userModel)
        {
            return Ok(userModel.ToString());
        }

        [HttpPost("register/author")]
        public IActionResult CheckInFroAuthor([FromBody] object authorModel)
        {
            return Ok(authorModel.ToString());
        }
    }
}

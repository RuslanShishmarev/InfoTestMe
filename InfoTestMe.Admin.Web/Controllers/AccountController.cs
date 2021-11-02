using InfoTestMe.Admin.Web.Models;
using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Admin.Web.Services;
using InfoTestMe.Common.Models;
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
        private readonly UsersService _userService;

        public AccountController(InfoTestMeDataContext db)
        {
            _userService = new UsersService(db);
        }

        /// <summary>
        /// Получение токена
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Создание нового пользователя, регистрация
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost("user")]
        public IActionResult CheckInForUser([FromBody] UserDTO userDTO)
        {
            if(userDTO != null)
            {
                bool actionResult =  _userService.Create(userDTO);
                return actionResult ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPatch("user")]
        public IActionResult UpdateUser([FromBody] UserDTO userDTO)
        {
            if (userDTO != null)
            {
                bool actionResult = _userService.Update(userDTO);
                return actionResult ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("user/{id}")]
        public IActionResult UpdateUser(int id)
        {
            if (id != 0)
            {
                bool actionResult = _userService.Delete(id);
                return actionResult ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        /// <summary>
        /// Регистрация автора
        /// </summary>
        /// <param name="authorDTO"></param>
        /// <returns></returns>
        [HttpPost("author")]
        public IActionResult CheckInFroAuthor([FromBody] AuthorDTO authorDTO)
        {
            if(authorDTO != null)
            {

            }
            return Ok();
        }
    }
}

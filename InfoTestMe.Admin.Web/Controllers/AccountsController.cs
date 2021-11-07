using InfoTestMe.Admin.Web.Models;
using InfoTestMe.Admin.Web.Models.Abstractions;
using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Admin.Web.Models.Data.Extensions;
using InfoTestMe.Admin.Web.Services;
using InfoTestMe.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TaskManagerCourse.Api.Models;

namespace InfoTestMe.Admin.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthorService _authorService;

        public AccountsController(InfoTestMeDataContext db)
        {
            _userService = new UserService(db);
            _authorService = new AuthorService(db);
        }

        /// <summary>
        /// Получение токена
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult GetToken(string type)
        {
            var userData = _userService.GetUserLoginPassFromBasicAuth(Request);
            
            var login = userData.userName;
            var pass = userData.userPassword;

            ClaimsIdentity identity = null;

            if (type == UserType.User.ToString().ToLower())
                identity = _userService.GetIdentity(login, pass, UserType.User);

            if (type == UserType.Author.ToString().ToLower())
                identity = _userService.GetIdentity(login, pass, UserType.Author);


            if (identity == null)
                return NotFound();

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
        [AllowAnonymous]
        [HttpPost("user")]
        public IActionResult CheckInForUser([FromBody] UserDTO userDTO)
        {
            if(userDTO != null || userDTO.Email != null)
            {
                bool isExist = _userService.IsExistUser(userDTO.Email);
                if (isExist)
                    return StatusCode(409);

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
            User currentUser = _userService.GetUserByLogin(HttpContext.User.Identity.Name);
            if(_userService.IsValid(userDTO))
            {
                if (currentUser?.Id == userDTO.Id)
                {
                    bool actionResult = _userService.Update(userDTO);
                    return actionResult ? Ok() : StatusCode(500);
                }
                return Unauthorized();
            }
            return BadRequest();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        [HttpDelete("user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            User currentUser = _userService.GetUserByLogin(HttpContext.User.Identity.Name);
            if (id != 0 && currentUser?.Id == id)
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
        [AllowAnonymous]
        [HttpPost("author")]
        public IActionResult CheckInAuthor([FromBody] AuthorDTO authorDTO)
        {            
            if (_userService.IsValid(authorDTO))
            {
                bool isExist = _authorService.IsExistAuthor(authorDTO.Email);
                if (isExist)
                    return StatusCode(409);

                bool actionResult = _authorService.Create(authorDTO);
                return actionResult ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        /// <summary>
        /// Обновление автора
        /// </summary>
        /// <param name="authorDTO"></param>
        /// <returns></returns>
        [HttpPatch("author")]
        public IActionResult UpdateAuthor([FromBody] AuthorDTO authorDTO)
        {
            Author currentAuthor = _authorService.GetAuthorByLogin(HttpContext.User.Identity.Name);
            if (_userService.IsValid(authorDTO) && currentAuthor != null && currentAuthor.Id == authorDTO.Id)
            {
                bool actionResult = _authorService.Update(authorDTO);
                return actionResult ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        /// <summary>
        /// Удаление автора
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("author/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            Author currentAuthor = _authorService.GetAuthorByLogin(HttpContext.User.Identity.Name);
            if (id != 0 && currentAuthor != null && currentAuthor.Id == id)
            {
                bool actionResult = _authorService.Delete(id);
                return actionResult ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        /// <summary>
        /// Получение информации текущего пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetCurrent(string type)
        {
            if(type == "user")
                return _userService.GetUserDTOByLogin(HttpContext.User.Identity.Name);

            if (type == "author")
                return _authorService.GetAuthorDTOByLogin(HttpContext.User.Identity.Name);            

            return null;
        }
    }
}

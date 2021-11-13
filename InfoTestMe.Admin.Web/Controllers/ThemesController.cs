using InfoTestMe.Admin.Web.Models.Abstractions;
using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Admin.Web.Services;
using InfoTestMe.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Controllers
{
    [Authorize(Roles = "Author")]
    [Route("api/[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private readonly ICourseThemeService _courseThemeService;
        private readonly IAuthorService _authorService;

        public ThemesController(InfoTestMeDataContext db)
        {
            _courseThemeService = new CourseThemeService(db);
            _authorService = new AuthorService(db);
        }

        /// <summary>
        /// Создание темы
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<int> CreateTheme([FromBody] CourseThemeDTO themeDTO)
        {
            if (themeDTO != null)
            {
                AuthorDTO author = _authorService.GetAuthorDTOByLogin(HttpContext.User.Identity.Name);
                if (author.Courses.Select(p => p.Id).Contains(themeDTO.CourseId))
                {
                    int id = _courseThemeService.CreateThemeAndGetId(themeDTO);
                    return Ok(id);
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Обновление темы
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        public IActionResult UpdateTheme([FromBody] CourseThemeDTO themeDTO)
        {
            if (themeDTO != null)
            {
                AuthorDTO author = _authorService.GetAuthorDTOByLogin(HttpContext.User.Identity.Name);
                if (author.Courses.Select(p => p.Id).Contains(themeDTO.CourseId))
                {
                    bool result = _courseThemeService.Update(themeDTO);
                    return result ? Ok() : StatusCode(500);
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Удаление темы
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteTheme([FromBody] CourseThemeDTO themeDTO)
        {
            if (themeDTO != null)
            {
                AuthorDTO author = _authorService.GetAuthorDTOByLogin(HttpContext.User.Identity.Name);
                if (author.Courses.Select(p => p.Id).Contains(themeDTO.CourseId))
                {
                    bool result = _courseThemeService.Delete(themeDTO.Id);
                    return result ? Ok() : StatusCode(500);
                }
            }
            return BadRequest();
        }
        
    }
}

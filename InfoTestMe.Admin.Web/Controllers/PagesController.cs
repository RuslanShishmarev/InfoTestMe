using InfoTestMe.Admin.Web.Models.Abstractions;
using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Admin.Web.Services;
using InfoTestMe.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly ICoursePageService _coursePageService;
        private readonly IAuthorService _authorService;
        public PagesController(InfoTestMeDataContext db)
        {
            _coursePageService = new CoursePageService(db);
            _authorService = new AuthorService(db);
        }
        /// <summary>
        /// Создание страницы курса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Author")]
        [HttpPost]
        public ActionResult<int> Create([FromBody] CoursePageDTO pageDTO)
        {
            if (pageDTO != null)
            {
                AuthorDTO author = _authorService.GetAuthorDTOByLogin(HttpContext.User.Identity.Name);
                if (author.Courses.Select(p => p.Id).Contains(pageDTO.CourseId))
                {
                    int newId = _coursePageService.CreatePageAndGetId(pageDTO);

                    return Ok(newId);
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Обновление страницы курса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Author")]
        [HttpPatch]
        public IActionResult Update([FromBody] CoursePageDTO pageDTO)
        {
            if (pageDTO != null)
            {
                AuthorDTO author = _authorService.GetAuthorDTOByLogin(HttpContext.User.Identity.Name);
                if (author.Courses.Select(p => p.Id).Contains(pageDTO.CourseId))
                {
                    var result = _coursePageService.Update(pageDTO);

                    return result ? Ok() : StatusCode(500);
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Удаление страницы курса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Author")]
        [HttpDelete]
        public IActionResult Delete([FromBody] CoursePageDTO pageDTO)
        {
            if (pageDTO != null)
            {
                AuthorDTO author = _authorService.GetAuthorDTOByLogin(HttpContext.User.Identity.Name);
                if (author.Courses.Select(p => p.Id).Contains(pageDTO.CourseId))
                {
                    var result = _coursePageService.Update(pageDTO);

                    return result ? Ok() : StatusCode(500);
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Получение страницы курса по id страницы
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<CoursePageDTO> GetCoursePage(int id)
        {
            if (id != 0)
            {
                var result = _coursePageService.Get(id);

                return result == null ? NotFound() : Ok(result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Получение страниц курса по id темы
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{themeId}")]
        public async Task<ActionResult<IEnumerable<CoursePageDTO>>> GetAllCoursePagesByTheme(int themeId)
        {
            if (themeId != 0)
            {
                var result = await _coursePageService.GetPagesByThemeId(themeId);

                return result == null ? NotFound() : Ok(result);
            }
            return BadRequest();
        }
    }
}

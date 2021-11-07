using InfoTestMe.Admin.Web.Models.Abstractions;
using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Admin.Web.Services;
using InfoTestMe.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InfoTestMe.Admin.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthorService _authorService;
        private readonly ICourseService _courseService;
        private readonly ICourseThemeService _courseThemeService;
        private readonly ICoursePageService _coursePageService;

        public CoursesController(InfoTestMeDataContext db)
        {
            _courseService = new CourseService(db);
            _coursePageService = new CoursePageService(db);
            _authorService = new AuthorService(db);
        }

        /// <summary>
        /// Получение курса по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<CourseDTO> GetCourse(int id)
        {
            if (id != 0)
            {
                var result = _courseService.Get(id);

                return result == null ? NotFound() : Ok(result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Получение курсов преподавателя
        /// </summary>
        /// <returns></returns>
        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<IEnumerable<AuthorProductDTO>>> GetCoursesByAuthor(int authorId)
        {
            if(authorId != 0)
            {
                var result = await _courseService.GetByAuthorId(authorId);

                return result == null ? NotFound() : Ok(result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Получение курсов ученика
        /// </summary>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<AuthorProductDTO>>> GetCoursesForUser(int userId)
        {
            if (userId != 0)
            {
                var result = await _courseService.GetByUserId(userId);

                return result == null ? NotFound() : Ok(result);
            }
            return BadRequest();
        }

        /*/// <summary>
        /// Получение тем курса
        /// </summary>
        /// <returns></returns>
        [HttpGet("{courseId}")]
        public async Task<ActionResult<IEnumerable<CourseThemeDTO>>> GetCourseThemes(int courseId)
        {
            if (courseId != 0)
            {
                var result = await _courseThemeService.GetAllThemeByCourseId(courseId);

                return result == null ? NotFound() : Ok(result);
            }
            return BadRequest();
        }*/

        /// <summary>
        /// Получение страниц курса по id темы
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("theme/{themeId}")]
        public async Task<ActionResult<IEnumerable<CoursePageDTO>>> GetAllCoursePagesByTheme(int themeId)
        {
            if (themeId != 0)
            {
                var result = await _coursePageService.GetPagesByThemeId(themeId);

                return result == null ? NotFound() : Ok(result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Получение страницы курса по id страницы
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("page/{id}")]
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
        /// Создание страницы курса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Author")]
        [HttpPost("page")]
        public IActionResult CreateCoursePage([FromBody] CoursePageDTO pageDTO)
        {
            if (pageDTO != null)
            {
                var result = _coursePageService.Create(pageDTO);

                return result ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        /// <summary>
        /// Обновление страницы курса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Author")]
        [HttpPatch("page")]
        public IActionResult UpdateCoursePage([FromBody] CoursePageDTO pageDTO)
        {
            if (pageDTO != null)
            {
                var result = _coursePageService.Update(pageDTO);

                return result ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        /// <summary>
        /// Удаление страницы курса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Author")]
        [HttpDelete("page/{pageId}")]
        public IActionResult DeleteCoursePage(int pageId)
        {
            if (pageId != 0)
            {
                var result = _coursePageService.Delete(pageId);

                return result ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        /// <summary>
        /// Создание курса
        /// </summary>
        /// <param name="value"></param>
        [Authorize(Roles = "Author")]
        [HttpPost]
        public IActionResult CreateCourse([FromBody] CourseDTO courseDTO)
        {
            if(courseDTO != null)
            {
                //get current author
                Author author = _authorService.GetAuthorByLogin(HttpContext.User.Identity.Name);
                courseDTO.AuthorId = author.Id;

                var result = _courseService.Create(courseDTO);

                return result ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        /// <summary>
        /// Обновление курса
        /// </summary>
        /// <param name="value"></param>
        [Authorize(Roles = "Author")]
        [HttpPatch]
        public IActionResult UpdateCourse([FromBody] CourseDTO courseDTO)
        {
            if (courseDTO != null)
            { 
                //get current author
                Author author = _authorService.GetAuthorByLogin(HttpContext.User.Identity.Name);
                courseDTO.AuthorId = author.Id;

                var result = _courseService.Update(courseDTO);

                return result ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        /// <summary>
        /// Удаление курса по id
        /// </summary>
        /// <param name="value"></param>
        [Authorize(Roles = "Author")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            if (id != 0)
            {
                var result = _courseService.Delete(id);

                return result ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }


        /// <summary>
        /// Записатся на курс пользователю
        /// </summary>
        /// <param name="value"></param>
        [HttpPut("users/add/{id}")]
        public IActionResult EnterCourse(int id)
        {
            if (id != 0)
            {
                //get current user
                User currentUser = _userService.GetUserByLogin(HttpContext.User.Identity.Name);

                var result = _userService.EnterToCourse(currentUser, id);

                return result ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

        // <summary>
        /// Отписаться на курс пользователю
        /// </summary>
        /// <param name="value"></param>
        [HttpPut("users/remove/{id}")]
        public IActionResult RemoveCourseFromUser(int id)
        {
            if (id != 0)
            {
                //get current user
                User currentUser = _userService.GetUserByLogin(HttpContext.User.Identity.Name);

                var result = _userService.OutCourse(currentUser, id);

                return result ? Ok() : StatusCode(500);
            }
            return BadRequest();
        }

    }
}

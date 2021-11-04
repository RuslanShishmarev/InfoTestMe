using InfoTestMe.Admin.Web.Models.Abstractions;
using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Admin.Web.Models.Data.Extensions;
using InfoTestMe.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Services
{
    public class CourseService : CommonService<CourseDTO>, ICourseService
    {
        public CourseService(InfoTestMeDataContext db) : base(db) { }

        #region PRIVATE METHODS
        private Course GetCourse(int id)
        {
            var course = DB.Courses.Include(c => c.Themes).FirstOrDefault(c => c.Id == id);
            return course;
        }

        private void CreateCourse(CourseDTO dto)
        {
            Course course = new Course()
            {
                AuthorId = dto.AuthorId,
                Name = dto.Name,
                Description = dto.Description,
                Image = dto.Image
            };
            DB.Courses.Add(course);

            if (dto.Themes?.Count > 0)
            {
                DB.SaveChanges();

                List<CourseTheme> themes = new List<CourseTheme>();
                foreach(CourseThemeDTO themeDTO in dto.Themes)
                {
                    CourseTheme courseTheme = new CourseTheme()
                    {
                        CourseId = course.Id,
                        Name = themeDTO.Name                        
                    };

                    themes.Add(courseTheme);
                }

                DB.CourseThemes.AddRange(themes);
            }            
        }

        private void UpdateCourse(CourseDTO dto)
        {
            Course course = GetCourse(dto.Id);

            course.Name = dto.Name;
            course.Description = dto.Description;
            course.Image = dto.Image;

            DB.Courses.Update(course);
        }

        private void DeleteCourse(int id)
        {
            Course course = GetCourse(id);
            DB.Courses.Remove(course);
        }

        

        #endregion
        public CourseDTO Get(int id)
        {
            return GetCourse(id).ToDTO();
        }

        public bool Create(CourseDTO dto)
        {
            return CreateOrUpdateActionData(CreateCourse, dto);
        }

        public bool Update(CourseDTO dto)
        {
            return CreateOrUpdateActionData(UpdateCourse, dto);
        }

        public bool Delete(int id)
        {
            return DeleteActionData(DeleteCourse, id);
        }

        public IEnumerable<CourseDTO> GetByAuthorId(int authorId)
        {
            return DB.Courses.Include(c => c.Themes).Where(c => c.AuthorId == authorId).Select(c => c.ToDTO());
        }

        public IEnumerable<CourseDTO> GetByUserId(int userId)
        {
            return DB.Courses.Include(c => c.Themes).Include(c => c.Users).Where(c => c.Users.Any(u => u.Id == userId)).Select(c => c.ToDTO());
        }
    }
}

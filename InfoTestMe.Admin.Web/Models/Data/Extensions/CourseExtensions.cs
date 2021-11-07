using InfoTestMe.Common.Models;
using System.Linq;

namespace InfoTestMe.Admin.Web.Models.Data.Extensions
{
    public static class CourseExtensions
    {
        public static CourseDTO ToDTO(this Course course)
        {
            return new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Image = course.Image,
                Themes = course.Themes?.Select(c => c.ToDTO()).ToList(),
                AllStudents = course.Users?.Select(c => c.ToShortDTO()).ToList(),
                CreationDate = course.CreationDate
            };
        }

        public static AuthorProductDTO ToShortDTO(this Course course)
        {
            return new AuthorProductDTO
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Image = course.Image,
                CreationDate = course.CreationDate
            };
        }
    }
}
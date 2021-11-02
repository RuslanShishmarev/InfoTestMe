using InfoTestMe.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Models.Data.Extensions
{
    public static class CourseExtensions
    {
        public static CourseDTO ToDTO(this Course course)
        {
            return new CourseDTO()
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Image = course.Image,
                Themes = course.Themes?.Select(c => c.ToDTO()).ToList(),
                AllStudents = course.Users?.Select(c => c.ToShortDTO()).ToList(),
            };
        }
    }
}
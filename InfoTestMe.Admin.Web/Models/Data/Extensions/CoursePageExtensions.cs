using InfoTestMe.Common.Models;
using System.Linq;

namespace InfoTestMe.Admin.Web.Models.Data.Extensions
{
    public static class CoursePageExtensions
    {
        public static CoursePageDTO ToDTO(this CoursePage coursePage)
        {
            return new CoursePageDTO()
            {
                Id = coursePage.Id,
                Name = coursePage.Name,
                Link = coursePage.Link,
                AudioFileName = coursePage.AudioFileName,
                AudioFile = coursePage.AudioFile,
                Blocks = coursePage.Blocks?.Select(c => c.ToDTO()).ToList(),
            };
        }
    }
}
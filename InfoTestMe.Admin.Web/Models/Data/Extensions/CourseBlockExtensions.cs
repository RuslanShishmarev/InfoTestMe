using InfoTestMe.Common.Models;

namespace InfoTestMe.Admin.Web.Models.Data.Extensions
{
    public static class CourseBlockExtensions
    {
        public static CourseBlockDTO ToDTO(this CourseBlock courseBlock)
        {
            return new CourseBlockDTO()
            {
                Id = courseBlock.Id,
                Text = courseBlock.Text,
                Image = courseBlock.Image,
            };
        }
    }
}
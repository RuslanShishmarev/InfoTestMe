using System.Collections.Generic;

namespace InfoTestMe.Common.Models
{
    public class CourseDTO : AuthorProductDTO
    {
        public int AuthorId { get; set; }
        public List<CourseThemeDTO> Themes { get; set; }
        public List<UserShortDTO> AllStudents { get; set; }
    }
}

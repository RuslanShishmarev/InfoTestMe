using System;
using System.Collections.Generic;

namespace InfoTestMe.Common.Models
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public List<CourseThemeDTO> Themes { get; set; }
        public List<UserShortDTO> AllStudents { get; set; }
    }
}

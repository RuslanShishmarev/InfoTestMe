using System;
using System.Collections.Generic;

namespace InfoTestMe.Common.Models
{
    public class CourseThemeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Pages { get; set; }
    }
}

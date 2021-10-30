using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.WebAPI.Models
{
    public class CourseTheme
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CoursePage> Pages { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}

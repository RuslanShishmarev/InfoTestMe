using System;

namespace InfoTestMe.WebAPI.Models
{
    public class AuthorCourse
    {
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}

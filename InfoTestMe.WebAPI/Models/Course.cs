using InfoTestMe.WebAPI.Models.Abstractions;
using System;
using System.Collections.Generic;

namespace InfoTestMe.WebAPI.Models
{
    public class Course : AuthorProduct
    {
        public Guid Id { get; set; }
        public List<CourseTheme> Themes { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}

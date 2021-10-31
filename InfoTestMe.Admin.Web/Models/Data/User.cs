using InfoTestMe.Admin.Web.Models.Abstractions;
using System;
using System.Collections.Generic;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class User : UserCommon
    {
        public Guid Id { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Test> Tests { get; set; } = new List<Test>();
    }
}

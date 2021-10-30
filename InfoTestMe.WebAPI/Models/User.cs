using InfoTestMe.WebAPI.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.WebAPI.Models
{
    public class User : UserCommon
    {
        public Guid Id { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Test> Tests { get; set; } = new List<Test>();
    }
}

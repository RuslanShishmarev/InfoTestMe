using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.WebAPI.Models
{
    public class CourseBlock
    {
        public Guid Id { get; set; }
        public byte[] Image { get; set; }
        public string Text { get; set; }
        public string LinkMaterial { get; set; }

        public Guid PageId { get; set; }
        public CoursePage Page { get; set; }
    }
}
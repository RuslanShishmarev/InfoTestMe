using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.WebAPI.Models
{
    public class CoursePage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CourseBlock> Blocks { get; set; }

        public string AudioFileName { get; set; }
        public byte[] AudioFile { get; set; }

        public Guid ThemeId { get; set; }
        public CourseTheme Theme { get; set; }
    }
}

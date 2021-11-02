using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.Common.Models
{
    public class CoursePageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public byte[] Image { get; set; }
        public string AudioFileName { get; set; }
        public byte[] AudioFile { get; set; }
        public List<CourseBlockDTO> Blocks { get; set; } = new List<CourseBlockDTO>();
    }
}

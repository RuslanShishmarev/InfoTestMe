using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class CoursePage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CourseBlock> Blocks { get; set; } = new List<CourseBlock>();
        public string Link { get; set; }
        public string AudioFileName { get; set; }
        public byte[] AudioFile { get; set; }

        [ForeignKey(nameof(ThemeId))]
        public int ThemeId { get; set; }
        public CourseTheme Theme { get; set; }
    }
}

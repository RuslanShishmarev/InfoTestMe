using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class CourseTheme
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CoursePage> Pages { get; set; } = new List<CoursePage>();

        [ForeignKey(nameof(CourseId))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

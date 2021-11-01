using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class CourseBlock
    {
        [Key]
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Text { get; set; }
        public string LinkMaterial { get; set; }

        [ForeignKey(nameof(PageId))]
        public int PageId { get; set; }
        public CoursePage Page { get; set; }
    }
}
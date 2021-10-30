using System;

namespace InfoTestMe.WebAPI.Models.Data
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
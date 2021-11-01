using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class TestAnswer
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public int QuestionId { get; set; }
        public TestQuestion Question { get; set; }
    }
}

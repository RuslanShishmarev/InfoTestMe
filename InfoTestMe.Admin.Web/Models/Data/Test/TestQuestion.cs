using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class TestQuestion
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public List<TestAnswer> Answers { get; set; } = new List<TestAnswer>();
        public byte[] Image { get; set; }

        [ForeignKey(nameof(TestId))]
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}

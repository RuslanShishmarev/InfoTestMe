using System;
using System.Collections.Generic;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class TestQuestion
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<TestAnswer> Answers { get; set; }

        public Guid TestId { get; set; }
        public Test Test { get; set; }
    }
}

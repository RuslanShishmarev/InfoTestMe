using System;

namespace InfoTestMe.WebAPI.Models
{
    public class TestAnswer
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; }

        public Guid QuestionId { get; set; }
        public TestQuestion Question { get; set; }
    }
}

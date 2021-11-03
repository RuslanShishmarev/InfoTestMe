using System;
using System.Collections.Generic;

namespace InfoTestMe.Common.Models
{
    public class TestQuestionDTO
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }
        public List<TestAnswerDTO> Answers { get; set; }

    }
}

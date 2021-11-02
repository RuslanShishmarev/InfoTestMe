using System;
using System.Collections.Generic;

namespace InfoTestMe.Common.Models
{
    public class TestQuestionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public List<TestAnswerDTO> Answers { get; set; }

    }
}

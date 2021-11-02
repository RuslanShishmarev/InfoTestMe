using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.WebAPI.Models
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

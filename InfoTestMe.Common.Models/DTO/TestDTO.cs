using System;
using System.Collections.Generic;

namespace InfoTestMe.Common.Models
{
    public class TestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public List<int> Questions { get; set; }
        public List<UserShortDTO> AllStudents { get; set; }

    }
}

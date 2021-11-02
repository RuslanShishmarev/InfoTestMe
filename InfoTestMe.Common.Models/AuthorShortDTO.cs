using System;

namespace InfoTestMe.Common.Models
{
    public class AuthorShortDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}

using System;

namespace InfoTestMe.Common.Models
{
    public class AuthorProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public object Image { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

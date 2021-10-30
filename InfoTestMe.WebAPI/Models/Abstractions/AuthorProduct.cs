using System;

namespace InfoTestMe.WebAPI.Models.Abstractions
{
    public abstract class AuthorProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

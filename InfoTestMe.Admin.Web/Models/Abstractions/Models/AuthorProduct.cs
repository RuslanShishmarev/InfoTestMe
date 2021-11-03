using System;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public abstract class AuthorProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

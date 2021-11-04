using System;

namespace InfoTestMe.Common.Models
{
    public class AuthorDTO : UserCommonDTO
    {
        public string Description { get; set; }
        public string[] KeyWords { get; set; }
    }
}

using InfoTestMe.WebAPI.Models.Abstractions;
using System;

namespace InfoTestMe.WebAPI.Models
{
    public class Author : UserCommon
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}

using InfoTestMe.Admin.Web.Models.Abstractions;
using System;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class Author : UserCommon
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}

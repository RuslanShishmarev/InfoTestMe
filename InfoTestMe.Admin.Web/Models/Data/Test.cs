using InfoTestMe.Admin.Web.Models.Abstractions;
using System;
using System.Collections.Generic;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class Test : AuthorProduct
    {
        public Guid Id { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}

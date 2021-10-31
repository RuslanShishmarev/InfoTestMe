using System;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class AuthorTest
    {
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public Guid TestId { get; set; }
        public Test Test { get; set; }
    }
}

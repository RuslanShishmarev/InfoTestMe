using InfoTestMe.Admin.Web.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class Test : AuthorProduct
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}

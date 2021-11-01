using InfoTestMe.Common.Models;
using System;
using System.Linq;

namespace InfoTestMe.Admin.Web.Models.Data.Extensions
{
    public static class AuthorExtensions
    {
        public static AuthorDTO ToDTO(this Author author)
        {
            return new AuthorDTO()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email,
                Password = author.Password,
                RegistrationDate = (DateTime)(author?.RegistrationDate),
                Image = author.Image,
                Courses = author.Courses?.Select(c => c.Id).ToList(),
                Tests = author.Tests?.Select(c => c.Id).ToList(),
            };
        }
    }
}

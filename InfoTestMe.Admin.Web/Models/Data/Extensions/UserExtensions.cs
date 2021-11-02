using InfoTestMe.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Models.Data.Extensions
{
    public static class UserExtensions
    {
        public static UserDTO ToDTO(this User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                RegistrationDate = user.RegistrationDate,
                Image = user.Image,
                Courses = user.Courses?.Select(c => c.Id).ToList(),
                Tests = user.Tests?.Select(c => c.Id).ToList(),
            };
        }
        public static UserShortDTO ToShortDTO(this User user)
        {
            return new UserShortDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Image = user.Image,
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.Common.Models
{
    public class UserCommonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public object Image { get; set; }
        public List<AuthorProductDTO> Courses { get; set; }
        public List<AuthorProductDTO> Tests { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Email}";
        }
    }
}

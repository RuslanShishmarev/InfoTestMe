using InfoTestMe.Common.Models;
using System.Linq;

namespace InfoTestMe.Admin.Web.Models.Data.Extensions
{
    public static class TestExtensions
    {
        public static TestDTO ToDTO(this Test test)
        {
            return new TestDTO()
            {
                Id = test.Id,
                Name = test.Name,
                Image = test.Image,
                Questions = test.Questions?.Select(c => c.ToDTO()).ToList(),
                AllStudents = test.Users?.Select(c => c.ToShortDTO()).ToList(),
                IsPublic = test.IsPublic
            };
        }
    }
}
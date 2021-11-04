using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Common.Models;
using System.Collections.Generic;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public interface IUserService : ICommonService<UserDTO>
    {
        List<UserShortDTO> GetByRange(int startPosition = 0, int countModels = 10);
        bool EnterToCourse(int userId, int courseId);
        bool EnterToCourse(User user, int courseId);
        bool OutCourse(User user, int courseId);
        User GetUserByLogin(string login);
    }
}

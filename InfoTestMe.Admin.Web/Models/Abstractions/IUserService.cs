using InfoTestMe.Common.Models;
using System.Collections.Generic;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public interface IUserService : ICommonService<UserDTO>
    {
        List<UserShortDTO> GetByRange(int startPosition = 0, int countModels = 10);
    }
}

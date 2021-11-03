using InfoTestMe.Common.Models;
using System.Collections.Generic;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public interface IAuthorService : ICommonService<AuthorDTO>
    {
        List<AuthorShortDTO> GetByRange(int startPosition = 0, int countModels = 10);
    }
}

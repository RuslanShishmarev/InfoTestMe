using InfoTestMe.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public interface ICourseService : ICommonService<CourseDTO>
    {
        Task<IEnumerable<AuthorProductDTO>> GetByAuthorId(int authorId);
        Task<IEnumerable<AuthorProductDTO>> GetByUserId(int userId);
    }
}

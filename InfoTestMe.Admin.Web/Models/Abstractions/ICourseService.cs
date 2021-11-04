using InfoTestMe.Common.Models;
using System.Collections.Generic;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public interface ICourseService : ICommonService<CourseDTO>
    {
        IEnumerable<CourseDTO> GetByAuthorId(int authorId);
        IEnumerable<CourseDTO> GetByUserId(int userId);
    }
}

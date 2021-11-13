using InfoTestMe.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public interface ICoursePageService : ICommonService<CoursePageDTO>
    {
        int CreatePageAndGetId(CoursePageDTO pageDTO);
        Task<IEnumerable<CoursePageDTO>> GetPagesByThemeId(int themeId);
    }
}

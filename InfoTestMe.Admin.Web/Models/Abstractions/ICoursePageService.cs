using InfoTestMe.Common.Models;
using System.Collections.Generic;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public interface ICoursePageService : ICommonService<CoursePageDTO>
    {
        IEnumerable<CoursePageDTO> GetPagesByThemeId(int themeId);
    }
}

using InfoTestMe.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public interface ICourseThemeService : ICommonService<CourseThemeDTO>
    {
        int CreateThemeAndGetId(CourseThemeDTO themeDTO);
        Task<IEnumerable<CourseThemeDTO>> GetAllThemeByCourseId(int courseId);
    }
}

using InfoTestMe.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public interface ICourseThemeService : ICommonService<CourseThemeDTO>
    {
        Task<IEnumerable<CourseThemeDTO>> GetAllThemeByCourseId(int courseId);
    }
}

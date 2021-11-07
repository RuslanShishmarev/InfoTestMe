using InfoTestMe.Admin.Web.Models.Abstractions;
using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Admin.Web.Models.Data.Extensions;
using InfoTestMe.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Services
{
    public class CourseThemeService : CommonService<CourseThemeDTO>, ICourseThemeService
    {
        public CourseThemeService(InfoTestMeDataContext db) : base(db) { }

        #region PRIVATE METHODS

        private CourseTheme GetTheme(int id)
        {
            return DB.CourseThemes.Include(t => t.Pages).FirstOrDefault(t => t.Id == id);
        }

        private void CreateTheme(CourseThemeDTO dto)
        {
            CourseTheme courseTheme = new CourseTheme()
            {
                CourseId = dto.CourseId,
                Name = dto.Name
            };

            DB.CourseThemes.Add(courseTheme);
        }

        private void UpdateTheme(CourseThemeDTO dto)
        {
            CourseTheme courseTheme = GetTheme(dto.Id);

            courseTheme.Name = dto.Name;

            DB.CourseThemes.Update(courseTheme);
        }

        public void DeleteTheme(int id)
        {
            CourseTheme courseTheme = GetTheme(id);
            DB.CourseThemes.Remove(courseTheme);
        }

        #endregion
        public CourseThemeDTO Get(int id)
        {
            return GetTheme(id).ToDTO();
        }

        public bool Create(CourseThemeDTO dto)
        {
            return CreateOrUpdateActionData(CreateTheme, dto);
        }

        public bool Update(CourseThemeDTO dto)
        {
            return CreateOrUpdateActionData(UpdateTheme, dto);
        }

        public bool Delete(int id)
        {
            return DeleteActionData(DeleteTheme, id);
        }

        public async Task<IEnumerable<CourseThemeDTO>> GetAllThemeByCourseId(int courseId)
        {
            return await DB.CourseThemes.Where(t => t.CourseId == courseId).Select(t => t.ToDTO()).ToListAsync();
        }
    }
}

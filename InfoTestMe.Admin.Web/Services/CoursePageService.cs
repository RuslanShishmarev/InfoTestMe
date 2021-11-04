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
    public class CoursePageService : CommonService<CoursePageDTO>, ICoursePageService
    {
        public CoursePageService(InfoTestMeDataContext db) : base(db) { }

        #region PRIVATE METHODS
        private CoursePage GetPage(int pageId)
        {
            return DB.CoursePages.Include(p => p.Blocks).FirstOrDefault(p => p.Id == pageId);
        }

        private void CreatePage(CoursePageDTO pageDTO)
        {
            CoursePage coursePage = new CoursePage()
            {
                ThemeId = pageDTO.ThemeId,
                Name = pageDTO.Name,
                Link = pageDTO.Link,
                AudioFileName = pageDTO.AudioFileName,
                AudioFile = pageDTO.AudioFile,
            };
            DB.CoursePages.Add(coursePage);
            DB.SaveChanges();


            if (pageDTO.Blocks != null && pageDTO.Blocks.Count > 0)
            {
                List<CourseBlock> courseBlocks = new List<CourseBlock>();
                foreach(CourseBlockDTO blockDTO in pageDTO.Blocks)
                {
                    CourseBlock courseBlock = new CourseBlock()
                    {
                        PageId = coursePage.Id,
                        Image = blockDTO.Image,
                        Text = blockDTO.Text
                    };
                    courseBlocks.Add(courseBlock);
                }
                DB.CourseBlocks.AddRange(courseBlocks);
            }            
        }

        private void UpdatePage(CoursePageDTO pageDTO)
        {
            CoursePage coursePage = GetPage(pageDTO.Id);

            coursePage.Name = pageDTO.Name;
            coursePage.Link = pageDTO.Link;
            coursePage.AudioFileName = pageDTO.AudioFileName;
            coursePage.AudioFile = pageDTO.AudioFile;

            if (pageDTO.Blocks != null && pageDTO.Blocks.Count > 0)
            {
                List<CourseBlock> courseBlocks = new List<CourseBlock>();

                foreach (CourseBlockDTO blockDTO in pageDTO.Blocks)
                {
                    //find block
                    CourseBlock block = DB.CourseBlocks.Find(blockDTO.Id);

                    if(block != null)
                    {
                        block.Image = blockDTO.Image;
                        block.Text = blockDTO.Text;
                        DB.CourseBlocks.Update(block);
                    }

                    else
                    {
                        CourseBlock courseBlock = new CourseBlock()
                        {
                            PageId = pageDTO.Id,
                            Image = blockDTO.Image,
                            Text = blockDTO.Text
                        };
                        DB.CourseBlocks.Add(courseBlock);
                    }
                }
            }

            DB.CoursePages.Update(coursePage);
        }

        private void DeletePage(int pageId)
        {
            CoursePage coursePage = GetPage(pageId);
            DB.CoursePages.Remove(coursePage);
        }
        #endregion
        public CoursePageDTO Get(int id)
        {
            return GetPage(id)?.ToDTO();
        }

        public bool Create(CoursePageDTO dto)
        {
            return CreateOrUpdateActionData(CreatePage, dto);
        }

        public bool Delete(int id)
        {
            return DeleteActionData(DeletePage, id);
        }

        

        public bool Update(CoursePageDTO dto)
        {
            return CreateOrUpdateActionData(UpdatePage, dto);
        }

        public IEnumerable<CoursePageDTO> GetPagesByThemeId(int themeId)
        {
            return DB.CoursePages.Include(p => p.Blocks).Where(p => p.ThemeId == themeId).Select(p => p.ToDTO());
        }
    }
}

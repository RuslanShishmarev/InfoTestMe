using InfoTestMe.Admin.Web.Models.Abstractions;
using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Services
{
    public class CourseService : CommonService<CourseDTO>, ICourseService
    {
        public CourseService(InfoTestMeDataContext db) : base(db) { }

        public bool Create(CourseDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CourseDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(CourseDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}

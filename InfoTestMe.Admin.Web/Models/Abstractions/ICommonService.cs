using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public interface ICommonService<TDto>
    {
        TDto Get(int id);        
        bool Create(TDto dto);
        bool Update(TDto dto);
        bool Delete(int id);
    }
}

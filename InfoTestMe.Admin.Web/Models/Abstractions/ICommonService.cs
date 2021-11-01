using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public interface ICommonService<T, TDto>
    {
        T Get(Guid id);
        TDto GetDto(Guid id);
        void Create(TDto dto);
        void Update(TDto dto);
        void Delete(Guid id);
    }
}

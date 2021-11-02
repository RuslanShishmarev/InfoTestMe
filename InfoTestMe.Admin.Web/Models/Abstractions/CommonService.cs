using InfoTestMe.Admin.Web.Models.Data;
using System;

namespace InfoTestMe.Admin.Web.Models.Abstractions
{
    public abstract class CommonService<T>
    {
        protected readonly InfoTestMeDataContext DB;

        public CommonService(InfoTestMeDataContext db)
        {
            DB = db;
        }

        protected bool CreateOrUpdateActionData(Action<T> action, T dto)
        {
            try
            {
                action?.Invoke(dto);
                DB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected bool DeleteActionData(Action<int> action, int id)
        {
            try
            {
                action?.Invoke(id);
                DB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

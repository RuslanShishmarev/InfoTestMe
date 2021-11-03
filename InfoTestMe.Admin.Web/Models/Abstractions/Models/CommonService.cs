using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Common.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

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

        private bool IsValidForAllPropertiesNull(object obj)
        {
            Type objType = obj.GetType();
            IList<PropertyInfo> properties = new List<PropertyInfo>(objType.GetProperties());

            foreach (PropertyInfo prop in properties)
            {
                object propValue = prop.GetValue(obj, null);
                if (propValue == null)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValid(UserCommonDTO userCommonDTO)
        {
            if (userCommonDTO == null
                || string.IsNullOrEmpty(userCommonDTO.Email)
                || string.IsNullOrEmpty(userCommonDTO.Password))
            {
                return false;
            }
            return true;
        }
    }
}

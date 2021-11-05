using Newtonsoft.Json;
using System;

namespace InfoTestMe.Admin.Web.Services
{
    public class FileService
    {
        public byte[] GetByteArrayFromJson(string jsonFile)
        {
            try
            {
                return JsonConvert.DeserializeObject<byte[]>(jsonFile);
            }
            catch
            {
                try
                {
                    return JsonConvert.DeserializeObject<byte[]>("[" + jsonFile + "]");
                }
                catch
                {
                    return Array.Empty<byte>();
                }
            }

        }
    }
}

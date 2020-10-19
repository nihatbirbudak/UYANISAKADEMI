using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UYK.DTO;

namespace UYK.WebUI.Admin.Core
{
    public class UYKConvert
    {
        public static string UYKJsonSerialize(object data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        public static CustomerDTO UYKJsonDeSerializeUserDTO(string data)
        {
            return JsonConvert.DeserializeObject<CustomerDTO>(data);
        }
    }
}

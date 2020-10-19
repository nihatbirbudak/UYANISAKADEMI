using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UYK.DTO;
using UYK.WebUI.Admin.Core;

namespace UYK.WebUI.Admin.Controllers
{
    public class BaseController : Controller
    {
        public CustomerDTO CurrentUser 
        { 
            get
            {
                var customerDTOjson = HttpContext.User.Claims.FirstOrDefault(z => z.Type == "CustomerDTO").Value;
                return UYKConvert.UYKJsonDeSerializeUserDTO(customerDTOjson);
            }
        }
    }
}

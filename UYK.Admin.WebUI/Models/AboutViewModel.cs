using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UYK.DTO;

namespace UYK.WebUI.Admin.Models
{
    public class AboutViewModel : IBaseViewModel
    {
        public CustomerDTO CurrentUser { get; set; }
        public AboutDTO AboutDTO { get; set; }
    }
}

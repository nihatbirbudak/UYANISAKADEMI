﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UYK.DTO;

namespace UYK.WebUI.Admin.Models
{
    public class IndexViewModel : IBaseViewModel
    {
        public CustomerDTO CurrentUser { get; set; }
    }
}

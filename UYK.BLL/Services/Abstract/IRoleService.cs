﻿using System;
using System.Collections.Generic;
using System.Text;
using UYK.Core.Services;
using UYK.DTO;

namespace UYK.BLL.Services.Abstract
{
    public  interface IRoleService : IServiceBase<RoleDTO>
    {
        public RoleDTO getRoleName(string roleName);
    }
}

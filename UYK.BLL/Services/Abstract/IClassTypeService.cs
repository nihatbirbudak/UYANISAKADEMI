using System;
using System.Collections.Generic;
using System.Text;
using UYK.Core.Services;
using UYK.DTO;

namespace UYK.BLL.Services.Abstract
{
    public interface IClassTypeService : IServiceBase<ClassTypeDTO>
    {
        public Dictionary<int, int> getClassCount();
    }
}

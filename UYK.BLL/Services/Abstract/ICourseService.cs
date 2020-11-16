using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UYK.Core.Services;
using UYK.DTO;
using UYK.Model;

namespace UYK.BLL.Services.Abstract
{
    public interface ICourseService : IServiceBase<CourseDTO>
    {
        public Dictionary<int, IEnumerable<int>> getCategoryCount();
        public Dictionary<int, IEnumerable<int>> getClassCount();
    }
}

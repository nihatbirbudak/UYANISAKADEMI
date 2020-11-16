using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UYK.DTO;

namespace UYK.WebUI.Admin.Models
{
    public class CourseClassTypeViewModel : IBaseViewModel
    {
        public CustomerDTO CurrentUser { get; set; }
        public ClassTypeDTO classTypeDTO { get; set; }
        public List<ClassTypeDTO> classTypeDTOs { get; set; }
        public int ChangeID { get; set; }
        public Dictionary<int,int> ClassCount { get; set; }
    }
}

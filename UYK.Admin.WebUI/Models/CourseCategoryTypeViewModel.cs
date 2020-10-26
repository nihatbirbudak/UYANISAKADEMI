using System.Collections.Generic;
using System.Linq;
using UYK.DTO;
using UYK.Model;

namespace UYK.WebUI.Admin.Models
{
    public class CourseCategoryTypeViewModel : IBaseViewModel
    {
        public CourseCategoryTypeDTO courseCategoryTypeDTO { get; set; }
        public List<CourseCategoryTypeDTO> courseCategoryTypeDTOs { get; set; }
        public CustomerDTO CurrentUser { get; set; }
        public Dictionary<int,int> CategoryCount { get; set; }
        public int ChangeId { get; set; }

    }
}

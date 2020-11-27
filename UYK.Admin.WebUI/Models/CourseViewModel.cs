using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UYK.DTO;

namespace UYK.WebUI.Admin.Models
{
    public class CourseViewModel : IBaseViewModel
    {
        public CustomerDTO CurrentUser { get; set; }
        public CourseDTO CourseDTO { get; set; }
        public List<CourseDTO> CourseDTOs { get; set; }
        public List<CourseCategoryTypeDTO> CourseCategoryTypeDTOs { get; set; }
        public List<ClassTypeDTO> ClassTypeDTOs { get; set; }
        public IFormFile File { get; set; }
    }
}
